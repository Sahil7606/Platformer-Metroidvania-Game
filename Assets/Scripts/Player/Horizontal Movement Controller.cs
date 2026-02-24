using System;
using UnityEngine;

public class HorizontalMovementController
{
    private PlayerCore core;
    private Rigidbody2D rigidbody;
    private Transform transform;

    public HorizontalMovementController(PlayerCore core)
    {
        this.core = core;
        rigidbody = core.rigidbody;
        transform = core.transform;
    }

    public void MoveX(float xInput, float runSpeed, float acceleration, float deceleration, float power, float frictionConstant)
    {
        float targetVelocity = xInput * runSpeed;
        float targetDeltaVelocity = targetVelocity - rigidbody.linearVelocityX;

        float accelerationRate = (Mathf.Abs(targetVelocity) > 0.01) ? acceleration : deceleration;

        float movement = Mathf.Pow(Mathf.Abs(targetDeltaVelocity) * accelerationRate, power) * Mathf.Sign(targetDeltaVelocity);

        rigidbody.AddForceX(movement);

        if (Mathf.Abs(xInput) < 0.01)
        {
            ApplyStopFriction(frictionConstant);
        }
    }

    private void ApplyStopFriction(float frictionConstant)
    {
        float frictionAmount = Mathf.Min(Mathf.Abs(rigidbody.linearVelocityX), frictionConstant) * -Mathf.Sign(rigidbody.linearVelocityX);

        rigidbody.AddForceX(frictionAmount, ForceMode2D.Impulse);
    }
}


