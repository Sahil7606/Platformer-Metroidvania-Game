using UnityEngine;

public abstract class SMCore : MonoBehaviour
{
    public StateMachine stateMachine = new StateMachine(); // Creates new state machine object
    public State state => stateMachine.state;
    public State initialState;
    [HideInInspector] public State previousState => stateMachine.previousState;
    private State nextState;

    // Sets up states on Awake
    protected virtual void Awake()
    {
        SetupStates();
    }

    //
    protected virtual void Start()
    {
        stateMachine.Set(initialState);
    }

    // See runState.GetNextState() in Entities\Player\States folder before trying to understand this
    public virtual void HandleStateSwitch(State state)
    {
        nextState = state.GetNextState();  // State returned by State.GetNextState() 
        
        // If the state returned by GetNextState() is different than the current state, then switch states
        if (state != nextState) 
        {
            stateMachine.Set(nextState);
        }
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
