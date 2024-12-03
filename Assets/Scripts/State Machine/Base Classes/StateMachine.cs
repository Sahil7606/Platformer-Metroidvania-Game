using UnityEngine;

public class StateMachine
{
    public State state {get; private set;} // Holds current state
    public State previousState {get; private set;} // Holds previous state
    public State nextState {get; private set;} // Holds next state
    public bool isTransitioning {get; private set;} // Keeps track of when the state machine is transitioning states
    
    // Sets the state to a new state
    public void Set(State newState)
    {
        isTransitioning = true;
        if (state != null)
        {
            state.Exit();
            previousState = state;
        }
        state = newState;
        Debug.Log($"Switched to state: {state.stateName}");
        state.Enter();
        isTransitioning = false;
    }

    public void EvaluateStateTransition(State state)
    {
        nextState = state.GetNextState();  // State returned by State.GetNextState() 
        
        // If the state returned by GetNextState() is different than the current state, then switch states
        if (state != nextState) 
        {
            Set(nextState);
        }
    }
}
