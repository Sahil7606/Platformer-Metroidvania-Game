using UnityEngine;

/*
This is meant to handle transitions between different states like jumping, attacking, falling, etc by using an enum
To learn about enums go here - https://www.youtube.com/watch?v=_kDuTk3qeAc
*/
public enum TraversalState
{
    Idle,
    Walking,
    Running,
    Jumping,
    Falling,
}

[RequireComponent(typeof(Rigidbody2D))]
public class TraversalStateMachine : MonoBehaviour
{
    // References to traversal action scripts
    [Header ("Traversal Scripts")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerJump playerJump;

    // References to sensors
    [Header ("Sensors")]
    [SerializeField] GroundChecker groundChecker;

    // Reference for the state machine that controls attacks
    [Header ("Attack State Machine - Optional")]

    private Rigidbody2D playerRigidbody;

    public TraversalState traversalState {get; private set;}// Keeps track of traversal state
    public bool isGrounded {get; private set;} // Checks if player is grounded
    public bool canAttack {get; private set;}

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        traversalState = TraversalState.Idle;
    }

    void Update() // Manages state in update to account for inputs between frames
    {
        ManageState();
    }

    void FixedUpdate() // All physics stuff done in fixed update
    {
        playerMovement.Move();

        if (traversalState == TraversalState.Jumping)
        {
            playerJump.Jump();
        }    
    }

    // Manages the player's state
    void ManageState()
    {   
        isGrounded = groundChecker.isGrounded;

        switch (traversalState)
        {
            case TraversalState.Idle:
                canAttack = true;
                if (Mathf.Abs(playerMovement.MoveInput.x) > Mathf.Epsilon) { SwitchState(TraversalState.Walking); break; }
                if (playerJump.jumpButtonDown && !playerJump.hasJumped) { SwitchState(TraversalState.Jumping); break; }
                if (playerRigidbody.velocity.y < Mathf.Epsilon && !isGrounded) { SwitchState(TraversalState.Falling); break; }
                break;
            case TraversalState.Walking:
                canAttack = true;
                if (Mathf.Abs(playerMovement.MoveInput.x) < Mathf.Epsilon) { SwitchState(TraversalState.Idle); break; }
                if (playerJump.jumpButtonDown && !playerJump.hasJumped) { SwitchState(TraversalState.Jumping); break; }
                if (playerRigidbody.velocity.y < Mathf.Epsilon && !isGrounded) { SwitchState(TraversalState.Falling); break; }
                break;
            case TraversalState.Jumping:
                canAttack = false;
                if (playerRigidbody.velocity.y < Mathf.Epsilon && !isGrounded) { SwitchState(TraversalState.Falling); break; }
                break;
            case TraversalState.Falling:
                canAttack = false;
                if (isGrounded) { SwitchState(TraversalState.Idle); break; }
                break;           
            
        }
    }

    void SwitchState(TraversalState state)
    {
        traversalState = state;
        Debug.Log("State Changed to " + traversalState);
    }
}
