using UnityEngine;

public class JumpState : PlayerState
{
    public override string stateName => "Jump";

    public override State GetNextState()
    {
        throw new System.NotImplementedException();
    }
}
