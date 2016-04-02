using UnityEngine;
using System.Collections;

public class FishState
{
    public enum states { approach, evade, wander }
    public states nextState;

	public FishState()
	{
		
	}

    public virtual void UpdateState() { }

	public virtual void ToEvadeState() { }

    public virtual void ToApproachState() { }

    public virtual void ToWanderState() { }

    public virtual void Start() { }

    public virtual void End() { }

    public void ChangeState(StateMachine parentStateMachine)
    {
        if (parentStateMachine.timeSinceLastPlayerSound < parentStateMachine.timeBeforeReturnToApproach)
        {
            nextState = states.evade;
        }
        else if (parentStateMachine.isInInterestPoint)
        {
            nextState = states.wander;
        }
        else
        {
            nextState = states.approach;
        }

        switch (nextState)
        {
            case states.approach:

                ToApproachState();
                break;
            case states.evade:
                ToEvadeState();
                break;
            case states.wander:
                ToWanderState();
                break;
        }
    }
}

