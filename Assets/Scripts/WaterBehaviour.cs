using UnityEngine;
using System.Collections;

public class WaterBehaviour : MonoBehaviour
{

    public float volume;
    public float maxVelocity = 10;

    public float minVelocity = 1;

    [Range(0.01f, 1.0f)]
    public float inertiaFactor = 0.5f;

    [Range(0.01f, 1.0f)]
    public float dilatationSpeed = 0.1f;

    [Range(0.0f, 128.0f)]
    public float fallAcceleration = 1.0f;



    [Range(0.0f, 128.0f)]
    public float magnetBreakDistance = 50.0f;

    [Range(0.0f, 128.0f)]
    public float magnetStrength = 50.0f;

    [Range(0.0f, 1.0f)]
    public float magnetTensor = 1.0f;

    [Range(0.0f, 1.0f)]
    public float concentratorForceRetention = 1.0f;

    //private float timeSinceHeavyProcess = 0;
    public Rigidbody rigidBody;
    private float temporalMagnitude = 0;

    public GameObject magnetTarget;
    public Color col;

    public Vector3 BounceForce = new Vector3(0,0,0);

    // Use this for initialization
    void Start()
    {
        col = Random.ColorHSV();
    }

    void Awake()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(rigidBody.velocity.magnitude);
        if (!rigidBody.isKinematic)
        {
            rigidBody = gameObject.GetComponent<Rigidbody>();
            temporalMagnitude = ((temporalMagnitude * 3.0f) + rigidBody.velocity.magnitude) * 0.2f;

            rigidBody.AddForce(BounceForce);
            BounceForce = BounceForce * concentratorForceRetention;


            float magnetDist = 0;
            if (magnetTarget != null)
            {
                magnetDist = Vector3.Distance(magnetTarget.transform.position, gameObject.transform.position);
                if (magnetDist >= magnetBreakDistance)
                {
                    magnetTarget = null;
                }
                else
                {
                    //Debug.DrawLine(gameObject.transform.position, magnetTarget.transform.position, magnetTarget.GetComponent<WaterBehaviour>().col);
                    rigidBody.AddForce((magnetTarget.transform.position - gameObject.transform.position).normalized * (magnetDist * magnetTensor) * magnetStrength);
                }
            }

            if (temporalMagnitude < maxVelocity)
            {
                if (temporalMagnitude > -minVelocity && temporalMagnitude < minVelocity)
                {
                    rigidBody.AddForce(rigidBody.velocity * inertiaFactor * 2);
                }

                if (rigidBody.velocity.y > 0)
                {
                    rigidBody.AddForce(-rigidBody.velocity * inertiaFactor);
                }
                else
                {
                    rigidBody.AddForce(rigidBody.velocity * inertiaFactor);
                }
            }

            if (1.2f - (Mathf.Min(1, (temporalMagnitude / (maxVelocity - minVelocity)))) > gameObject.GetComponent<SphereCollider>().radius)
            {
                gameObject.GetComponent<SphereCollider>().radius += dilatationSpeed;
            }
            else if (1.1f - (Mathf.Min(1, (temporalMagnitude / (maxVelocity - minVelocity)))) < gameObject.GetComponent<SphereCollider>().radius)
            {
                gameObject.GetComponent<SphereCollider>().radius -= dilatationSpeed;
            }

           /* timeSinceHeavyProcess += Time.deltaTime;
            if (timeSinceHeavyProcess >= heavyProcessInterval)
            {
                timeSinceHeavyProcess -= heavyProcessInterval;
                //heavyProcessSimulation();
            }*/
            rigidBody.velocity *= Mathf.Min(1, maxVelocity / temporalMagnitude);
            if (!GetComponent<CharacterController>().isGrounded)
            {
                rigidBody.AddForce(new Vector3(-0.5f, -fallAcceleration, 0.5f));
            }
            //Debug.DrawLine(gameObject.transform.position, gameObject.transform.position+rigidBody.velocity, magnetTarget.GetComponent<WaterBehaviour>().col);

        }
    }



  /*  private void heavyProcessSimulation()
    {




        float dist = 0.25f;
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, dist);
        while (hitColliders.Length < attractingNeibords)
        {
            dist += 0.25f;
            hitColliders = Physics.OverlapSphere(this.transform.position, dist);
        }


        //rigidBody.velocity /=  0.40f+dist;
        //if(dist>1)
        //Debug.Log(dist);
        Vector3 averagePosition = new Vector3(0, 0, 0);
        int nbWater = 0;
        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject.tag == "WaterDrop")
            {
                collider.gameObject.GetComponent<Rigidbody>().AddForce(rigidBody.velocity);
                averagePosition += collider.gameObject.transform.position;
                rigidBody.AddExplosionForce(-attractionForce, collider.gameObject.transform.position, attractionForce * dist);

                nbWater++;
            }
        }
        averagePosition /= nbWater;
        rigidBody.AddForce((transform.position - averagePosition) * (dist));
    }

    /* void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.tag == "Bassin")
         {
             other.GetComponent<Bassin>().RaiseLevel(volume);
             Object.Destroy(this.gameObject);
         }

     }*/

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Bassin")
        {
            other.GetComponentInParent<Bassin>().RaiseLevel(volume);
            /* if (gameObject.transform.parent.childCount == 1)
             {
                 Object.Destroy(gameObject.transform.parent.gameObject);
             }
             else
             {
                 Object.Destroy(this.gameObject);
             }*/
            //GameObject.FindGameObjectWithTag("Faucet").GetComponent<Faucet>().releaseWater(gameObject);
            Faucet.releaseWater(gameObject);
        }

    }
}
