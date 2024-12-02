using UnityEngine;

public abstract class State : MonoBehaviour
{
    // Keeps track of states runtime
    [HideInInspector] protected float startTime; 
    public float stateRuntime => Time.time - startTime; // For checking in Update()
    public float stateFixedRuntime => Time.fixedTime - startTime; // For checking in FixedUpdate()
    public abstract string stateName {get;} // Each state has a name used for debugging
    
    // Each state must define a function SetupCore() that grants State access to main components and core
    public abstract void SetCore(SMCore core);

    public virtual void Initialize() { } // Run at Awake()
    public virtual void Enter() { startTime = Time.time; } // Run on transition into state
    public virtual void Exit() { } // Run on transition out of state
    public virtual void StateUpdate() { } // Run in Update(), use for non-physics related code
    public virtual void StateFixedUpdate() { } // Run in FixedUpdate(), use for physics related code

    // Each state must define GetNextState() that tells the core when to transition to another state
    public abstract State GetNextState();
}
