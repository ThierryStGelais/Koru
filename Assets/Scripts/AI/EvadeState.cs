using UnityEngine;
using System.Collections;

public class EvadeState : FishState
{
    private readonly StateMachine parentStateMachine;

    private Vector3 initialPos;
    private Vector3 soundPos;
    private Vector3 targetPos;
	private RaycastHit hit;
	private float rotationSpeed ;
	private int range;

	public EvadeState(StateMachine stateMachine):base()
    {
        parentStateMachine = stateMachine;
    }

    public override void Start()
    {
		range = 4;
		rotationSpeed =7.0f;
        initialPos = parentStateMachine.transform.position;
        soundPos = parentStateMachine.soundPosition;
		targetPos = initialPos - soundPos;
        targetPos.y = 0;
		parentStateMachine.fishReference.Evade(targetPos);
		parentStateMachine.GetComponent<ConstantForce> ().relativeForce= new Vector3(0,0,parentStateMachine.fishReference.evadeSpeed);
        parentStateMachine.fishReference.animator.SetBool("IsPanic?", true);
        foreach (ParticleSystem element in parentStateMachine.fishReference.spashlingParticule)
        {
            if (element.name == "ParticuleMiddle")
                element.emissionRate = parentStateMachine.fishReference.baseEmissionRateMiddle;
            else
                element.emissionRate = parentStateMachine.fishReference.baseEmissionRateWave;
        }
    }

    public override void UpdateState()
    {
        nextState = states.evade;
        if (!parentStateMachine.fishReference.isDed) 
		{
			Transform rightRay =  parentStateMachine.transform.FindChild("rightRay");
			Transform leftRay = parentStateMachine.transform.FindChild("leftRay");
			if (Physics.Raycast (leftRay.position , leftRay.transform.forward,out hit, range, 13)) 
			{
				if (hit.collider.gameObject.gameObject.tag == "Untagged")
				{
					parentStateMachine.transform.RotateAround(parentStateMachine.transform.position, Vector3.up, rotationSpeed);
				}
			}
			if (Physics.Raycast(rightRay.position, rightRay.transform.forward,out hit ,range, 13)) 
			{
				if (hit.collider.gameObject.gameObject.tag == "Untagged") 
				{
					parentStateMachine.transform.RotateAround (parentStateMachine.transform.position, Vector3.up, -rotationSpeed);
				}
			}
		}

        //Change de State
        ChangeState(parentStateMachine);
    }

    public override void ToEvadeState()
    {
        // Ne peut faire de transition vers le meme etat
    }

    public override void ToApproachState()
    {
        parentStateMachine.fishReference.animator.SetBool("IsPanic?", false);
        foreach (ParticleSystem element in parentStateMachine.fishReference.spashlingParticule)
        {
            element.emissionRate = 0.0f;
        }
        parentStateMachine.currentState = parentStateMachine.approachState;
        parentStateMachine.approachState.Start();
    }

    public override void ToWanderState()
    {
        parentStateMachine.fishReference.animator.SetBool("IsPanic?", false);
        foreach (ParticleSystem element in parentStateMachine.fishReference.spashlingParticule)
        {
            element.emissionRate = 0.0f;
        }
        parentStateMachine.currentState = parentStateMachine.wanderState;
    }
}