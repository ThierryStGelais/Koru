using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlankFixNameNotFound : MonoBehaviour {

    private List<GameObject> playersColliding;
    public float outClipSpeed = 0.1f;

	// Use this for initialization
	void Start () {
        playersColliding = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    /*void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playersColliding.Add(other.gameObject);
        } 
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playersColliding.Remove(other.gameObject);
        }
    }*/


    void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Debug.Log("triggerStayPlankFix");
            other.transform.position += new Vector3(0,(transform.parent.position.y-other.transform.position.y+1.0f),0);
        }
    }
}
