using UnityEngine;
// TODO: Manage State transitions in a heirarchical state machine

public abstract class State : MonoBehaviour
{
    /*
    =====================================================================================
    References for non-hierarchical state machines
    =====================================================================================
    */

    [HideInInspector] protected float startTime; 
    public float stateRuntime => Time.time - startTime; // For checking in Update()
    public float stateFixedRuntime => Time.fixedTime - startTime; // For checking in FixedUpdate()
    public abstract string stateName {get;} // Each state has a name used for debugging
    

    /*
    =====================================================================================
    Functions for non-hierarchical state machines
    =====================================================================================
    */

    // State must define SetCore() that grants State access to main components and core
    public abstract void SetCore(SMCore core);
    public virtual void Initialize() { } // Run at Awake()
    public virtual void Enter() { startTime = Time.time; } // Run on transition into state
    public virtual void Exit() { } // Run on transition out of state
    public virtual void StateUpdate() { } // Run in Update(), use for non-physics related code
    public virtual void StateFixedUpdate() { } // Run in FixedUpdate(), use for physics related code
    public abstract State GetNextState(); // State must define GetNextState(); tells the core when to transition


    /*
    =====================================================================================
    References and functions for hierarchical state machines
    =====================================================================================
    */

    protected StateMachine stateMachine = new StateMachine(); // Reference to state machine for hierarchical states
    protected State subState => stateMachine.state; // Reference to the current substate
    protected State parentState; // Reference to the parent state

    public void TryGetParentState(State parent) // Sets the parent state
    {
        parentState = GetComponentInParent<State>();
    }

    public void StateUpdateHierarchy() // Run in Update() for hierarchical states
    {
        StateUpdate();
        subState?.StateUpdateHierarchy();
    }

    public void StateFixedUpdateHierarchy() // Run in FixedUpdate() for hierarchical states
    {
        StateFixedUpdate();
        subState?.StateFixedUpdateHierarchy();
    }
}
