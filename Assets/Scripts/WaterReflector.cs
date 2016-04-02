using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaterReflector : MonoBehaviour {


    private Vector3 leftPoint;
    private Vector3 rightPoint;

    public bool isOnPlayer = false;

    // Use this for initialization
    void Start () {

        if (isOnPlayer)
        {
            leftPoint = transform.position - (transform.forward * 1000);
            rightPoint = transform.position + (transform.forward * 1000);
        }
        else
        {
            leftPoint = transform.position - (transform.right * 1000);
            rightPoint = transform.position + (transform.right * 1000);
        }
    }

    // Update is called once per frame
    void Update () {
        if (isOnPlayer)
        {
            leftPoint = transform.position - (transform.forward * 1000);
            rightPoint = transform.position + (transform.forward * 1000);
            //Debug.DrawLine(transform.position, leftPoint, Color.red);
           // Debug.DrawLine(transform.position, rightPoint, Color.blue);
        }
       
    }


   /* void OnTriggerExit(Collider other)
    {
        Vector3 rightVect = transform.transform.right;
        if (isOnPlayer)
        {
            rightVect = transform.transform.forward;
        }

        if ( other.gameObject.tag == "WaterDrop")
        {
            WaterBehaviour water = other.GetComponent<WaterBehaviour>();
            Vector3 dropPoint = other.transform.position + (water.rigidBody.velocity.normalized * 1000);
            if (Vector3.Distance(dropPoint, leftPoint) >= Vector3.Distance(dropPoint, rightPoint))
            {
                water.rigidBody.velocity += rightVect * 10;
                if(isOnPlayer)
                    Debug.DrawLine(water.transform.position, water.transform.position+ water.rigidBody.velocity, Color.yellow);

            }
            else
            {
                water.rigidBody.velocity -= rightVect * 10;
                if (isOnPlayer)
                    Debug.DrawLine(water.transform.position, water.transform.position - rightVect * 10, Color.green);

            }
        }

    }*/

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WaterDrop")
        {
            WaterBehaviour water = other.GetComponent<WaterBehaviour>();
            water.rigidBody.velocity = water.rigidBody.velocity.normalized;
        }

    }

    void OnTriggerStay(Collider other)
    {
        Vector3 rightVect = transform.transform.right;
        if (isOnPlayer)
        {
            rightVect = transform.transform.forward;
        }

        if ( other.gameObject.tag == "WaterDrop")
        {
            WaterBehaviour water = other.GetComponent<WaterBehaviour>();
            Vector3 dropPoint = other.transform.position + (water.rigidBody.velocity.normalized * 1000);
            if (Vector3.Distance(dropPoint, leftPoint) >= Vector3.Distance(dropPoint, rightPoint))
            {
                water.rigidBody.velocity += rightVect;
            }
            else
            {
                water.rigidBody.velocity -= rightVect;
            }

        }

    }

}
