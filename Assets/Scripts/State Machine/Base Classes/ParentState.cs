public abstract class ParentState : State
{
    private State childState;
    private State nextState;
    private readonly StateMachine stateMachine = new StateMachine();

    protected abstract State GetInitialChildState();
    protected virtual void ParentStateEnter() { } 
    protected virtual void ParentStateExit() { }
    protected virtual void ParentStateUpdate() { }
    protected virtual void ParentStateFixedUpdate() { }

    public override void Enter()
    {
        childState = GetInitialChildState();
        childState?.Enter();
        ParentStateEnter();
    }

    public override void Exit()
    {
        childState?.Exit();
        ParentStateExit();
    }

    public override void StateUpdate()
    {
        childState.StateUpdate();
        ParentStateUpdate();
    }

    public override void StateFixedUpdate()
    {
        childState.StateFixedUpdate();
        ParentStateFixedUpdate();
    }
    
    public virtual void HandleStateSwitch(State state)
    {
        nextState = state.GetNextState();  // State returned by State.GetNextState() 
        
        // If the state returned by GetNextState() is different than the current state, then switch states
        if (state != nextState) 
        {
            stateMachine.Set(nextState);
        }
    }
}
