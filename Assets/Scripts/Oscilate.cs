using UnityEngine;
using System.Collections;

public class Oscilate : MonoBehaviour {

    private Vector3 originPos;
    public float speed = 1;
    public float range = 0.4f;
    public bool floating;

	// Use this for initialization
	void Start () {

        //originPos = this.gameObject.transform.position;
        floating = false;

	}

    public void SetPos()
    {
        originPos = this.gameObject.transform.position;
        floating = true;
    }

	// Update is called once per frame
	void Update () {

        if(floating)
            this.gameObject.transform.position = originPos + new Vector3(0, Mathf.Sin(Time.time*speed)*range, 0);

    }
}
