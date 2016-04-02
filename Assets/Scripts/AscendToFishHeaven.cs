using UnityEngine;
using System.Collections;

public class AscendToFishHeaven : MonoBehaviour {

    public float ascentSpeed = 5.0f;
    public float timeBeforeDespawn = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeBeforeDespawn -= Time.deltaTime;
        this.transform.Translate(this.transform.up *Time.deltaTime * ascentSpeed);
        Destroy(this.gameObject , timeBeforeDespawn);
	}
}
