using UnityEngine;

public class StateMachine
{
    public State state {get; private set;} // Holds current state
    public State previousState {get; private set;} // Holds previous state
    public bool isTransitioning {get; private set;}
    
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
}
