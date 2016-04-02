using UnityEngine;
using System.Collections;

public class FloatOnTouch : MonoBehaviour {

    private bool isActive = true;
    [Range(1.0f, 10.0f)]
    public float ocilationSpeed = 1.0f;
    [Range(1.0f, 16.0f)]
    public float ocilationAmplitude = 1.0f;
    [Range(-2.0f, 2.0f)]
    public float offset = 0.0f;
    public bool isOccilating = false;
    public float maxVelocity = 2.5f;
    private float velocity = 0.1f;
    public void setVelocity(float _v) {velocity = _v;}

    private Bassin ocean;
    private Rigidbody rigidBody;

    // Use this for initialization
    void Start () {
        ocean = GameObject.FindGameObjectWithTag("OceanRef").GetComponentInParent<Bassin>();
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
      
        if (isActive)
        {
            

            if (ocean.getWaterLevelAtMyLocation(gameObject)> transform.position.y)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, ocean.getWaterLevelAtMyLocation(gameObject) + offset, gameObject.transform.position.z);
                if (gameObject.transform.parent == null)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity))
                    {
                        if(hit.transform.name == "Water")
                        {
                            transform.parent = hit.transform;
                            gameObject.GetComponent<BoxCollider>().isTrigger = false;
                            
                        }
                    }
                }
            }
            if (gameObject.transform.parent != null)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, ocean.getWaterLevelAtMyLocation(gameObject) + offset, gameObject.transform.position.z);
                if (isOccilating)
                {
                    gameObject.transform.position += (new Vector3(0, Mathf.Sin(Time.time * ocilationSpeed), 0) * Time.deltaTime * ocilationAmplitude);
                }
            }
            
        }
    }

    void FixedUpdate()
    {
        if (transform.CompareTag("Pickable"))
        {
            if (gameObject.GetComponent<BoxCollider>().isTrigger)
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = false;
            }
        }
        //float velocity = 0.5f;
       if (transform.parent == null)
        {
            if (gameObject.tag == "Pickable" )
            {
                
                RaycastHit tooClose;
                //Debug.DrawRay(transform.position, -Vector3.up, Color.magenta, 5.0f);
                if (velocity >= 0.05f) { 
                    if (Physics.Raycast(transform.position, -Vector3.up, out tooClose, velocity, 1 << 0))
                    {
                    
                        transform.position = new Vector3(transform.position.x, tooClose.point.y, transform.position.z);
                        velocity = 0.04f;
                    }
                    else
                    {
                
                        transform.Translate(-velocity * Vector3.up);
                        velocity *= 1.1f;
                    }
                }
            }
       }        
      
        RaycastHit hit;
        if (gameObject.tag == "Pickable")
        {
            //rigidBody.isKinematic = (transform.parent!=null ? transform.parent.name == "Water" : false);
            if (Physics.Raycast(transform.position, Vector3.up, out hit, Mathf.Infinity, 1 << 0))
            {
                if (hit.transform.CompareTag("Untagged"))
                {
                    if (transform.parent != null)
                    {
                        transform.parent = null;
                        transform.position += 2 * Vector3.up;
                        //gameObject.GetComponent<BoxCollider>().isTrigger = true;

                    }
                    transform.position = hit.point + (1.4f * Vector3.up);
                }
            }
        }


    }
    public void Disable() {

        isActive = false;
        gameObject.transform.parent = null;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().useGravity = true;

    }

    public void Enable()
    {

        isActive = true;


    }

    void OnTriggerEnter(Collider other)
    {

        if (gameObject.tag !="Pickable" && isActive && other.gameObject.tag == "Water")
        {
            gameObject.transform.parent = other.gameObject.transform;
            if (gameObject.tag != "Fish")
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }

    }


}
