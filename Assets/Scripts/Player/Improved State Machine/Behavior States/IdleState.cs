using Unity.VisualScripting;
using UnityEngine;

public class IdleState : PlayerState
{
    public override string stateName => "Idle";

    public override State GetNextState()
    {
        if (Mathf.Abs(input.horizontalInput.x) > Mathf.Epsilon)
        {
            return null;
        }

        return null;
    }
}
