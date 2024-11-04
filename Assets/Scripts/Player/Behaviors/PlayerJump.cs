using UnityEngine;
using UnityEngine.InputSystem;

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

[RequireComponent(typeof(TraversalStateMachine))]
public class PlayerJump : MonoBehaviour
{
    [Header ("Components")]
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] Animator playerAnimator;

    [Header ("Jump Properties")]
    [SerializeField] float jumpHeight;        // Initial jump height
    [SerializeField] float jumpHoldStrength;  // Additional height when holding jump
    [SerializeField] float maxHoldTime;       // Max duration for hold-boost

    [HideInInspector] public bool jumpButtonDown;
    [HideInInspector] public bool hasJumped;  // Prevents repeated jumping
    private float buttonHoldTime;             // Time the jump button is held
    private bool initialForceApplied;         // Tracks if initial jump force was applied

    // Reference to player state machine
    TraversalStateMachine stateMachine;

    private void Start()
    {
        // Gets the player state machine
        stateMachine = GetComponent<TraversalStateMachine>();
    }

    // Handles jump mechanics
    private void FixedUpdate()
    {
        // Tracks the time the button is held down
        if (jumpButtonDown && initialForceApplied)
        {
            buttonHoldTime += Time.fixedDeltaTime;
        }
        else
        {
            // Resets hold time for next jump
            buttonHoldTime = 0;
        }

        // If not jumping anymore, reset the initial force flag
        if (stateMachine.traversalState != TraversalState.Jumping)
        {
            initialForceApplied = false;
        }

        PlayJumpAnim();
    }

    // Input system callback when jump button is pressed
    void OnJump(InputValue jumpButton)
    {
        // Tracks if the jump button is pressed
        jumpButtonDown = jumpButton.isPressed;
        if (!jumpButtonDown)
        {
            hasJumped = false; // Reset jump when button is released
        }
    }

    // Main jump logic
    public void Jump()
    {
        // Initial force for the jump
        if (!initialForceApplied)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpHeight);
            hasJumped = true;
            initialForceApplied = true;
        }
        // Apply additional boost when the button is held
        else if (jumpButtonDown && hasJumped && buttonHoldTime <= maxHoldTime)
        {
            playerRigidbody.velocity += new Vector2(0, jumpHoldStrength - (buttonHoldTime / 3.5f));
        }
    }

    // Controls jumping animation based on state
    void PlayJumpAnim()
    {
        playerAnimator.SetBool("IsJumping", stateMachine.traversalState == TraversalState.Jumping);
    }
}

