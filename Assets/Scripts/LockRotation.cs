using UnityEngine;
using System.Collections;

public class LockRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {

        transform.localRotation = Quaternion.Euler(-transform.parent.rotation.eulerAngles);

    }
}
