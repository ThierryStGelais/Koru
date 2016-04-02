using UnityEngine;
using System.Collections.Generic;

public class Fish : MonoBehaviour
{
    [Header("Fish Attributes")]
    public int detectionRange = 5;
    public float normalSpeed = 15.0f;
    public float evadeSpeed = 10.0f;
    private static List<GameObject> nearFish = new List<GameObject>();
    private static GameObject[] interestPoints = null;
    [HideInInspector]
    public bool isDed = false;
    private bool isSinking = false;
    private bool[] highlight = new bool[2] { false, false };
    public ParticleSystem[] spashlingParticule;
    public float baseEmissionRateWave;
    public float baseEmissionRateMiddle;

    public GameObject nearestPoint = null;
    [HideInInspector]
    public bool isTargeted = false;
    public Animator animator;
    [Header("Fish Death Attributes")]
    public float timeBeforeCorpseExpiration = 5.0f;
    public float timeBeforeCorpseSinking = 1.0f;
    [Header("Fish Highlights")]
    public Material Base;
    public Material P1;
    public Material P2;
    public Material P1P2;
    [Header("Fish Dead")]
    public Material Dead;
    private int layermask = 1 << 11;
    private float displacementValue = 2;
    private float timeTillStartAnim;
    private bool animationIsPlaying = false;
    StateMachine machine;


    // Use this for initialization
    void Start()
    {
        if (interestPoints == null)
        {
            interestPoints = GameObject.FindGameObjectsWithTag("Interest");
        }
        FindNearFish();

        animator = this.GetComponentsInChildren<Animator>()[0]; //Si sa brise c'est parce que l'anim de poisson est pas le premier child pis jte blame toi.
        animator.speed = 0.7f;
        timeTillStartAnim = Random.Range(0, 4);

        spashlingParticule = this.transform.FindChild("ParticulePanic").GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem element in spashlingParticule)
        {
            if (element.name == "ParticuleMiddle")
                baseEmissionRateMiddle = element.emissionRate;
            else
                baseEmissionRateWave = element.emissionRate;
            element.emissionRate = 0.0f;      //fuck you unity je fais ske je veux
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!animationIsPlaying && timeTillStartAnim <= 0)
        {
            animationIsPlaying = true;
            animator.speed = 1;

        }
        else
        {
            timeTillStartAnim -= Time.deltaTime;
        }
        if (isDed)
            timeBeforeCorpseSinking -= Time.deltaTime;
        if (timeBeforeCorpseSinking < 0 && !isSinking)
            Sink();
        animator.SetFloat("Speed", this.GetComponent<Rigidbody>().velocity.magnitude);
        if(!isDed)
            ApplyHighlightMaterial();



    }

    void FixUpdate()
    {
        FindClosestInterestPoint();
    }

    public void Sink()
    {
        isSinking = true;
        gameObject.GetComponent<FloatOnTouch>().Disable();
        Destroy(this.gameObject, timeBeforeCorpseExpiration);
    }

    public ParticleSystem[] GetSplashParticule()
    {
        return spashlingParticule;
    }


    public void Die()
    {
        isDed = true;
        //GetComponent<ConstantForce>().relativeForce= Vector3.zero;
        Renderer render = GetComponentInChildren<Renderer>();
        render.material = Dead;
        GameManager.Instance.GetComponent<AudioManager>().FishDeathSound();
        animator.SetBool("IsDead?", true);
        Instantiate(Resources.Load("Ghost") as GameObject, this.transform.position, this.transform.rotation);
 
    }

    public void FindNearFish()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, detectionRange);
        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject.tag == "Fish")
            {
                nearFish.Add(collider.gameObject);
            }
        }
    }

    public void FindClosestInterestPoint(StateMachine stateM = null)
    {
        float Elevation;
        if (stateM != null && nearestPoint != null)
        {

            Elevation = Mathf.Abs(nearestPoint.transform.position.y - gameObject.transform.position.y);
            if (Elevation > 2.0f || nearestPoint == this.gameObject)
            {
                stateM.isInInterestPoint = true;
            }
        }

        interestPoints = GameObject.FindGameObjectsWithTag("Interest");

        if (interestPoints.Length > 0)
        {
            float nearestDist = 99999;

            GameObject nearest = this.gameObject;
            if (nearestPoint != null)
            {
                nearest = nearestPoint;
            }


            foreach (GameObject point in interestPoints)
            {
                RaycastHit hit = Raycast(point.GetComponent<Collider>());
                Elevation = Mathf.Abs(point.transform.position.y - gameObject.transform.position.y);
                if (hit.collider != null && hit.collider.tag == "Interest" && Elevation < 2.0f)
                {
                    if (Vector3.Distance(point.transform.position, gameObject.transform.position) < nearestDist)
                    {
                        nearestDist = Vector3.Distance(point.transform.position, gameObject.transform.position);
                        nearest = point;
                    }
                }
            }
            nearestPoint = nearest;
        }

    }

    public void Evade(Vector3 targetPos)
    {
        if (!isDed)
        {
            targetPos.Normalize();
            this.transform.LookAt(transform.position + targetPos);
            GetComponent<Rigidbody>().velocity = targetPos * (evadeSpeed / 1.8f);
        }
    }

    public void MakeHighlight(int noPlayer, bool onOrOff)
    {
        highlight[noPlayer - 1] = onOrOff;
    }

    private void ApplyHighlightMaterial()
    {
        Renderer render = GetComponentInChildren<Renderer>();
        if (highlight[0] == true && highlight[1] == true)
        {
            render.material = P1P2;
            /*
            animator.SetBool("IsPanic?", true);
            foreach (ParticleSystem element in spashlingParticule)
            {
                if (element.name == "ParticuleMiddle")
                    element.emissionRate = baseEmissionRateMiddle;
                else
                    element.emissionRate = baseEmissionRateWave;
            }
            */
        }
        else if (highlight[0] == true && highlight[1] == false)
        {
            render.material = P1;
            /*
            animator.SetBool("IsPanic?", true);
            foreach (ParticleSystem element in spashlingParticule)
            {
                if (element.name == "ParticuleMiddle")
                    element.emissionRate = baseEmissionRateMiddle;
                else
                    element.emissionRate = baseEmissionRateWave;
            }
            */
        }
        else if (highlight[0] == false && highlight[1] == true)
        {
            render.material = P2;
            /*
            animator.SetBool("IsPanic?", true);
            foreach (ParticleSystem element in spashlingParticule)
            {
                if (element.name == "ParticuleMiddle")
                    element.emissionRate = baseEmissionRateMiddle;
                else
                    element.emissionRate = baseEmissionRateWave;
            }
            */
        }
        else
        {
            render.material = Base;
            /*
            animator.SetBool("IsPanic?", false);
            foreach (ParticleSystem element in spashlingParticule)
            {
                element.emissionRate = 0.0f;
            }
            */
        }
    }



    private RaycastHit Raycast(Collider element)
    {
        RaycastHit hit;
        Vector3 PlayerWithDisplacement = this.gameObject.transform.position;
        Vector3 InteresthWithDisplacement = element.transform.position + new Vector3(0, displacementValue, 0);


        Physics.Raycast(PlayerWithDisplacement                                         //Origin (Player+displacement)
                        , InteresthWithDisplacement - PlayerWithDisplacement                  //Direction (Player+displacement jusqua Fish+Displacement)
                        , out hit                                                        //Hit info
                        , Vector3.Distance(PlayerWithDisplacement, InteresthWithDisplacement) //Distance (Player+displacement jusqua Fish+Displacement)
                        , layermask                                                      //LayerMask
                        );

        return hit;
    }
}