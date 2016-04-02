using UnityEngine;
using System.Collections;

public class ApproachState : FishState
{
	protected readonly StateMachine parentStateMachine;

	protected Transform rightRay;
	protected Transform leftRay;
	protected int range;
	protected float speed ;
	protected bool isThereAnyThing = false;
	protected Vector3 target;
	protected RaycastHit hit;
	protected float rotationSpeed;
	public float dispersionRange = 3.0f;

	public ApproachState(StateMachine stateMachine):base()
    {
        parentStateMachine = stateMachine;
		speed = parentStateMachine.fishReference.normalSpeed;
		hit = new RaycastHit ();
		rightRay =  parentStateMachine.transform.FindChild("rightRay");
		leftRay = parentStateMachine.transform.FindChild("leftRay");
	}

    public override void Start()
    {
		range = 3;
		rotationSpeed =18.0f;
		dispersionRange = 3.0f;
		parentStateMachine.GetComponent<ConstantForce> ().relativeForce= new Vector3(0,0,speed);
		parentStateMachine.fishReference.FindClosestInterestPoint();

        target = parentStateMachine.fishReference.nearestPoint.transform.position+ new Vector3(Random.Range(-dispersionRange,dispersionRange),0,Random.Range(-dispersionRange,dispersionRange));
    }

    public override void UpdateState()
    {
        nextState = states.approach;
		//Look At Somthly Towards the Target if there is nothing in front.
		if(!parentStateMachine.fishReference.isDed || !GameManager.Instance.getPlayersManager().gamePaused)
        {
            if (!isThereAnyThing)
            {
                Vector3 relativePos = (target - parentStateMachine.transform.position) * 1.5f + (2 * new Vector3(Random.Range(-dispersionRange, dispersionRange), 0, Random.Range(-dispersionRange, dispersionRange)));
                Quaternion rotation = Quaternion.LookRotation(relativePos);
                parentStateMachine.transform.rotation = Quaternion.Slerp(parentStateMachine.transform.rotation, rotation, Time.deltaTime);
            }
            isThereAnyThing = false;

            //Use Phyics.RayCast to detect the obstacle
            if (Physics.Raycast(leftRay.position, leftRay.transform.forward, out hit, range))
            {
                if (hit.collider.gameObject.gameObject.tag != "Water" && hit.collider.gameObject.gameObject.tag != "Player")
                {
                    isThereAnyThing = true;
                    parentStateMachine.transform.RotateAround(parentStateMachine.transform.position, Vector3.up, rotationSpeed + Random.Range(0, 4));
                }
            }
            if (Physics.Raycast(rightRay.position, rightRay.transform.forward, out hit, range))
            {
                if (hit.collider.gameObject.gameObject.tag != "Water" && hit.collider.gameObject.gameObject.tag != "Player")
                {
                    isThereAnyThing = true;
                    parentStateMachine.transform.RotateAround(parentStateMachine.transform.position, Vector3.up, -rotationSpeed - Random.Range(0, 4));
                }
            }

            // Now Two More RayCast At The End of Object to detect that object has already pass the obsatacle.
            // Just making this boolean variable false it means there is nothing in front of object.
            if (Physics.Raycast(parentStateMachine.transform.position - (parentStateMachine.transform.forward * 3), parentStateMachine.transform.right, out hit, 4) ||
                Physics.Raycast(parentStateMachine.transform.position - (parentStateMachine.transform.forward * 3), -parentStateMachine.transform.right, out hit, 4))
            {
                if (hit.collider.gameObject.tag != "Water")
                {
                    isThereAnyThing = false;
                }
            }
            // Use to debug the Physics.RayCast.
            //Debug.DrawRay (parentStateMachine.transform.position , leftRay.transform.forward.normalized*range, Color.red);
            //Debug.DrawRay (parentStateMachine.transform.position, rightRay.transform.forward.normalized*range, Color.red);
            //Debug.DrawRay (parentStateMachine.transform.position - (parentStateMachine.transform.forward * 3), - parentStateMachine.transform.right * 4, Color.yellow);
            //Debug.DrawRay (parentStateMachine.transform.position - (parentStateMachine.transform.forward * 3), parentStateMachine.transform.right * 4, Color.yellow);
        }

        //Change de State
        parentStateMachine.fishReference.FindClosestInterestPoint(parentStateMachine);

        ChangeState(parentStateMachine);
    }

    public override void ToApproachState()
    {
        //Ne peut faire de transition vers le meme etat
    }

    public override void ToEvadeState()
    {
		parentStateMachine.GetComponent<ConstantForce> ().relativeForce= Vector3.zero;
        parentStateMachine.currentState = parentStateMachine.evadeState;
        parentStateMachine.evadeState.Start();
    }

    public override void ToWanderState()
    {
		parentStateMachine.GetComponent<ConstantForce> ().relativeForce= Vector3.zero;
		parentStateMachine.currentState = parentStateMachine.wanderState;
    }
}
