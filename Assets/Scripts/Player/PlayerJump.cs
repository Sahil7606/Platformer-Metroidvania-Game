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

    [Header ("Jump Properties")]

    [SerializeField] float jumpHeight;
    [SerializeField] float jumpHoldStrength; // How much boost to be added on button hold
    [SerializeField] float maxHoldTime; // Maximum time that boost can be applied for

    [HideInInspector] public bool jumpButtonDown;

    float buttonHoldTime; // Keeps track of how long button is held

    // Reference to player state machine
    PlayerStateMachine stateMachine;

    void Start()
    {
        // Gets player state machine
        stateMachine = GetComponent<PlayerStateMachine>();
    }

    // Keeps track of how long Jump Button is held
    void Update()
    {
        if (jumpButtonDown)
        {
            buttonHoldTime += Time.deltaTime;
        }
        else
        {
            // Resets to prepare for next jump
            buttonHoldTime = 0;
        }
    }

    // Stops player from holding button in order to repeatedlly jump
    private bool hasJumped;
    void OnJump(InputValue jumpButton)
    {
        if (jumpButton.isPressed && stateMachine.CurrentState == PlayerState.Grounded && !hasJumped)
        {
            jumpButtonDown = true;
        }
        else if (!jumpButton.isPressed)
        {
            jumpButtonDown = false;
            hasJumped = false;
        }
    }

    public void Jump()
    {
        // Adds initial force to jump if grounded
        Debug.Log(jumpButtonDown); 
        if (jumpButtonDown && stateMachine.CurrentState == PlayerState.Grounded && !hasJumped)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpHeight);
            hasJumped = true;
        }
        else if (jumpButtonDown && stateMachine.CurrentState == PlayerState.Jumping && hasJumped) // Adds boost when holding button down
        {
            if (buttonHoldTime <= maxHoldTime)
            {
                // Subtract holdtime to gradually lower boost in order to smoothen the jump
                playerRigidbody.velocity += new Vector2(0, jumpHoldStrength - (buttonHoldTime / 3.5f));
            }
        }
    }
}
