using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaterConcentrator : MonoBehaviour {

    private List<GameObject> magnetsBalls = new List<GameObject>();
    private List<int> magnetsCpt = new List<int>();

    private int chainQuantity;
    private int chainLenght;
    private int chainOffset;

    private int chainCpt = 0;

    public Vector3 temporalBounceVector = new Vector3(0,0,0);

    [Range(0.0f, 1.0f)]
    public float temporalVectorRetention = 0.9f;


    [Range(0.0f, 1.0f)]
    public float temporalVectorDuration = 0.9f;

    [Range(1, 10000)]
    public float temporalVectorStrenght = 1000.0f;


    private List<GameObject> lastBounceObject = new List<GameObject>();
    private List<float> lastBounceObjectTime = new List<float>();

    private Vector3 lastBouncePosition;



    // Use this for initialization
    void Start () {

        chainQuantity = Faucet._chainQuantity;
        chainLenght = Faucet._chainLenght;
        chainOffset = Faucet._chainOffset;

        for (int i = 0; i < chainQuantity; i++)
        {
            magnetsBalls.Add(null);
            magnetsCpt.Add((chainOffset * i) % chainLenght);
        }
    }

    // Update is called once per frame
    void Update () {
        for ( int i = 0 ; i < lastBounceObject.Count ; i++ )
        {
            lastBounceObjectTime[i] -= Time.deltaTime;
            if (lastBounceObjectTime[i] <= 0)
            {
                
                Vector3 toLastBall = (lastBounceObject[i].transform.position - transform.position).normalized;
                if (toLastBall.magnitude >= 100)
                {
                    temporalBounceVector = (temporalBounceVector * temporalVectorRetention) + (toLastBall * (1 - temporalVectorRetention));
                }
                lastBounceObject.RemoveAt(i);
                lastBounceObjectTime.RemoveAt(i);
            }
        }
	}


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "WaterDrop")
        {
            if (magnetsCpt[chainCpt] >= chainLenght)
            {
                magnetsCpt[chainCpt] = 0;
                magnetsBalls[chainCpt] = other.gameObject;
                other.GetComponent<WaterBehaviour>().magnetTarget = null;
            }
            else if (magnetsBalls[chainCpt] == null)
            {
                magnetsBalls[chainCpt] = other.gameObject;
                other.GetComponent<WaterBehaviour>().magnetTarget = null;
            }
            else
            {
                other.GetComponent<WaterBehaviour>().magnetTarget = magnetsBalls[chainCpt];
            }
            other.GetComponent<WaterBehaviour>().BounceForce = temporalBounceVector * temporalVectorStrenght;
            magnetsCpt[chainCpt]++;
            chainCpt++;
            if (chainCpt >= chainQuantity)
            {
                chainCpt = 0;
            }
            lastBounceObject.Add(other.gameObject);
            lastBounceObjectTime.Add(temporalVectorDuration);
        }

    }

}
