using UnityEngine;
using System.Collections;

public class DestroyOnTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
            Destroy(gameObject);
    }


}
