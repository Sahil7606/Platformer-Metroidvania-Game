using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerCore))]
public class PlayerInputManager : MonoBehaviour
{
    public Vector2 AxisInput {get; private set;}
    public bool jumpButtonDown {get; private set;}
    public bool attackButtonDown {get; private set;}
    private void OnMove(InputValue value)
    {
        AxisInput = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            jumpButtonDown = true;
        }
        else
        {
            jumpButtonDown = false;
        }
    }

    private void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            attackButtonDown = true;
        }
        else
        {
            attackButtonDown = false;
        }
    }
}
