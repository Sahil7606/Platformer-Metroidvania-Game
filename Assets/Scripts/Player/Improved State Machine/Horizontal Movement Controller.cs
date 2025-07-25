using UnityEngine;

public class HorizontalMovementController
{
    private PlayerCore core;
    private Rigidbody2D rigidbody;
    private Transform transform;

    public HorizontalMovementController(PlayerCore _core)
    {
        core = _core;
        rigidbody = _core.rigidbody;
        transform = _core.transform;
    }

    public void MoveX(float xInput, float runSpeed, float acceleration, float deceleration)
    {
        float targetVelocity = xInput * runSpeed;
        float targetDeltaVelocity = targetVelocity - rigidbody.linearVelocityX;

        float acceleration_rate = (Mathf.Abs(targetDeltaVelocity) > Mathf.Epsilon) ? acceleration : deceleration;

        rigidbody.AddForceX(targetDeltaVelocity * acceleration_rate);
    }
}
