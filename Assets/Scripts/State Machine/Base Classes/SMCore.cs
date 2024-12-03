using UnityEngine;

public abstract class SMCore : MonoBehaviour
{
    protected StateMachine stateMachine = new StateMachine(); // Creates new state machine object
    public State state => stateMachine.state;
    public State nextState => stateMachine.nextState;
    public State initialState;
    [HideInInspector] public State previousState => stateMachine.previousState;
    

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
