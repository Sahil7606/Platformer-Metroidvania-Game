using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerCore))]
public class InputManager : MonoBehaviour
{
    // Variables notify the other scripts of when an input is pressed
    public Vector2 horizontalInput { get; private set; }
    public bool jumpButtonDown { get; private set; }

    // Uses input system to track input
    private void OnMove(InputValue input)
    {
        horizontalInput = input.Get<Vector2>();
        Debug.Log(horizontalInput);
    }

    private void OnJump(InputValue input)
    {
        if (input.isPressed)
        {
            Debug.Log("Jump button down");
        }
        else
        {
            jumpButtonDown = false;
            Debug.Log("Jump button not down");
        }
    }
}
