using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : PlayerState
{
    public override string stateName => "Attacking";


    public override State GetNextState()
    {
        throw new System.NotImplementedException();
    }
}
