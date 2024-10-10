using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

/*
Jump Full Implementation Details

MUST HAVES:
    Player jumps higher on button hold
    Player falls faster than he rises
    Player jump feels "heavy"

    SPECIFICS:
        Max Jump height is about 3.5 units
        Min Jump height is about 1 unit

IMPLEMENT LATER:
    Particle effect on landing
    Coyote Time
    Slight camera shake
    Jump Attacks

*/

[RequireComponent(typeof(PlayerStateMachine))]
public class PlayerJump : MonoBehaviour
{
    [Header ("Components")]

    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] Animator playerAnimator;
    [SerializeField] GroundChecker groundChecker;

    [Header ("Jump Properties")]

    [SerializeField] float jumpHeight;
    [SerializeField] float jumpHoldStrength; // How much boost to be added on button hold
    [SerializeField] float maxHoldTime; // Maximum time that boost can be applied for

    [HideInInspector] public bool isJumping;

    bool jumpButtonDown;
    float buttonHoldTime; // Keeps track of how long button is held


    // Keeps track of how long Jump Button is held
    void FixedUpdate()
    {
        if (isJumping)
        {
            buttonHoldTime += Time.fixedDeltaTime;
        }
        else
        {
            // Resets to prepare for next jump
            buttonHoldTime = 0;
        }
    }

    // Detects when button is pressed
    void OnJump(InputValue jumpButton)
    {
        if (jumpButton.isPressed && groundChecker.isGrounded)
        {
            jumpButtonDown = true;
        }
        else if (!jumpButton.isPressed)
        {
            jumpButtonDown = false;
        }
    }

    public void Jump()
    {
        // Adds initial force to jump
        if (jumpButtonDown && !isJumping)
        {
            isJumping = true;
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpHeight);
        }
        else if (jumpButtonDown && isJumping) // Adds boost when holding button down
        {
            if (buttonHoldTime <= maxHoldTime)
            {
                // Subtract holdtime to gradually lower boost in order to smoothen the jump
                playerRigidbody.velocity += new Vector2(0, jumpHoldStrength - (buttonHoldTime / 3.5f));
            }
        }
        else if (!jumpButtonDown)
        {
            isJumping = false;
        }
    }
}
