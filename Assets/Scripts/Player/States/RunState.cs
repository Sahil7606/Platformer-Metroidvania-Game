using UnityEngine;

public class RunState : PlayerState
{
    // The name of this state
    public override string stateName => "Running";

    // Called when the state is entered
    public override void Enter()
    {
        // Set the animator parameter to indicate the player is running
        animator.SetBool("IsRunning", true);
    }

    // Called when the state is exited
    public override void Exit()
    {
        // Reset the animator parameter to indicate the player is no longer running
        animator.SetBool("IsRunning", false);
    }

    // Determine the next state based on player input and conditions
    public override State GetNextState()
    {
        // If there is no horizontal input, transition to the idle state
        if (Mathf.Abs(input.AxisInput.x) < Mathf.Epsilon)
        {
            return core.idleState;
        }

        // If the jump button is pressed, transition to the jump state
        if (input.jumpButtonDown)
        {
            return core.jumpState;
        }

        // If the player is not grounded, transition to the air state
        if (!core.isGrounded)
        {
            return core.airState;
        }

        // Remain in the running state
        return this;
    }

}
