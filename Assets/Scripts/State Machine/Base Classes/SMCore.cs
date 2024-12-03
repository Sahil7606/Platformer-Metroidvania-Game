using UnityEngine;

public abstract class SMCore : MonoBehaviour
{
    /*
    =====================================================================================
    References to state machine and states
    =====================================================================================
    */

    protected StateMachine stateMachine = new StateMachine(); // Creates new state machine object
    public State state => stateMachine.state; // Reference to the current state
    public State nextState => stateMachine.nextState; // Reference to the next state
    [HideInInspector] public State previousState => stateMachine.previousState; // Reference to the previous state
    [SerializeField] protected State initialState; // Initial state for the state machine


    /*
    =====================================================================================
    Functions for State Machine cores
    =====================================================================================
    */
     
    // Sets up states on Awake
    protected virtual void Awake()
    {
        SetupStates();
    }

    // Sets the initial state on Start
    protected virtual void Start()
    {
        stateMachine.Set(initialState);
    }

    // Gets each state from child objects and sets their SMCore to itself and initializes each state
    protected void SetupStates()
    {
        State[] states = GetComponentsInChildren<State>();
        foreach (State state in states)
        {
            state.SetCore(this);
            state.Initialize();
        }
    }
}
