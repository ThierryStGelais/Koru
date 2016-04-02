using UnityEngine;
using System.Collections;

public class WanderState : FishState {
    private readonly StateMachine parentStateMachine;

	public WanderState(StateMachine stateMachine):base()
	{
		
		parentStateMachine = stateMachine;

    }

    public override void UpdateState()
	{
		ToApproachState ();

		// Debug.Log("Wander State");
        nextState = states.wander;


        //Change de State
        ChangeState(parentStateMachine);
	}


    public override void ToWanderState()
    {
        // Ne peut faire de transition vers le meme etat
    }

    public override void ToEvadeState()
    {
        parentStateMachine.currentState = parentStateMachine.evadeState;
        parentStateMachine.evadeState.Start();
    }

    public override void ToApproachState()
    {
        parentStateMachine.currentState = parentStateMachine.approachState;
        parentStateMachine.approachState.Start();
    }
}
