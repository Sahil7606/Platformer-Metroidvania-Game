using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : State
{
    protected PlayerCore core;
    protected new Rigidbody2D rigidbody;
    protected Animator animator;
    protected PlayerInputManager input;

    public override void SetCore(SMCore _core)
    {
        core = _core as PlayerCore;
        rigidbody = core.rigidbody;
        animator = core.animator;
        input = core.input;
    }
}
