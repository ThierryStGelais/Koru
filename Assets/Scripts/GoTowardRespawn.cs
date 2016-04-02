using UnityEngine;
using System.Collections;

public class GoTowardRespawn : MonoBehaviour {

    public Vector3 startMarker;
    public Vector3 endMarker;
    public float speed = 2.0F;
    private float startTime;
    private float journeyLength;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker, endMarker);
        speed = journeyLength / 2.0f;
        Destroy(this.gameObject, 2.2f);
    }
	
	// Update is called once per frame
	void Update () {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
        this.transform.LookAt(endMarker);
    }
}
