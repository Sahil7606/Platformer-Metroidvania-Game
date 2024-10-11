using UnityEngine;

/*
This is meant to handle transitions between different states like jumping, attacking, falling, etc by using an enum
To learn about enums go here - https://www.youtube.com/watch?v=_kDuTk3qeAc
*/
public enum PlayerState
{
    Grounded,
    Jumping,
    Falling
}

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerStateMachine : MonoBehaviour
{
    [Header ("Action Scripts")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerJump playerJump;
    
    [Header ("Sensors")]
    [SerializeField] GroundChecker groundChecker;

    Rigidbody2D playerRigidbody;

    public PlayerState CurrentState {get; private set;}

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

        // Initialize state to falling
        CurrentState = PlayerState.Falling;
    }

    void FixedUpdate()
    {
        playerMovement.Move();
        playerJump.Jump();

        if (groundChecker.isGrounded && Mathf.Abs(playerRigidbody.velocity.y) < Mathf.Epsilon)
        {
            CurrentState = PlayerState.Grounded;
        }
        else if (playerJump.jumpButtonDown && CurrentState == PlayerState.Grounded)
        {
            CurrentState = PlayerState.Jumping;
        }
        // Epsilon is a number close to 0. Used to stop floating point errors.
        else if (playerRigidbody.velocity.y < -1 * Mathf.Epsilon && CurrentState != PlayerState.Grounded) 
        {
            CurrentState = PlayerState.Falling;
        }

        Debug.Log(CurrentState);
    }
}
