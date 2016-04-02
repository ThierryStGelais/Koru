using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Fish))]


public class StateMachine : MonoBehaviour
{
    [HideInInspector]
    public float timeBeforeReturnToApproach = 0.0f;

    public float fleeingTime = 10.0f;


    [HideInInspector]
    public float timeSinceLastPlayerSound;
    [HideInInspector]
    public bool isInInterestPoint = false;
    public Fish fishReference;


    
    public FishState currentState;
    [HideInInspector]
    public EvadeState evadeState;
    [HideInInspector]
    public ApproachState approachState;
    [HideInInspector]
    public WanderState wanderState;
    [HideInInspector]
    public Vector3 soundPosition;

    private void Awake()
    {
        evadeState = new EvadeState(this);
        approachState = new ApproachState(this);
        wanderState = new WanderState(this);
    }

    // Use this for initialization
    void Start()
    {
        timeSinceLastPlayerSound = fleeingTime;
        fishReference = this.gameObject.GetComponent<Fish>();
        currentState = approachState;
        currentState.Start();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastPlayerSound += Time.deltaTime;
        currentState.UpdateState();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Interest")
        {
            isInInterestPoint = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Interest")
        {
            isInInterestPoint = false;
        }
    }

    public void HearSound(float fleeingModifier, Vector3 Position)
    {
        soundPosition = Position;
        timeSinceLastPlayerSound = 0;
        timeBeforeReturnToApproach = fleeingTime * fleeingModifier;
        evadeState.Start();
    }

}