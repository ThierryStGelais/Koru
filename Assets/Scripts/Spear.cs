using UnityEngine;
using System.Collections;

public class Spear : MonoBehaviour {

    private Vector3 targetPos;
    private GameObject target;
    private float startTime;
    private float dist;
    [SerializeField]
    private Material spearMat;
    public float speed = 0.000001f;



	// Use this for initialization
	void Start ()
    {
        spearMat = this.gameObject.GetComponent<MeshRenderer>().material;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(target == null)
            Destroy(this.gameObject);
        if(transform.parent == null)
            MoveToTarget();
        else { gameObject.GetComponent<MeshRenderer>().material = spearMat; }
    }

    private void MoveToTarget()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        transform.LookAt(target.transform);

        if (transform.position == target.transform.position)
        {
            target.SendMessage("Die", SendMessageOptions.DontRequireReceiver);
            transform.parent = target.transform.GetChild(0).GetChild(0); //Si sa brise c'est parce que l'anim de poisson est pas le premier child pis jte blame toi. 

        }
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }
}
