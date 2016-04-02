using UnityEngine;
using System.Collections;

public class WaterAddToBassin : MonoBehaviour {

    public float volume;
    public float maxVelocity = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
        if (rigidBody.velocity.magnitude < maxVelocity)
        {
            if (rigidBody.velocity.y > -0.5f && rigidBody.velocity.y < 0.5f)
            {
                rigidBody.AddForce(new Vector3(-1,0,1));
            }

            if (rigidBody.velocity.y > 0)
            {
                rigidBody.AddForce(-rigidBody.velocity);
            }
            else
            {
                rigidBody.AddForce(rigidBody.velocity);
            }
        }
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
            other.GetComponent<Bassin>().RaiseLevel(volume);
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
