using UnityEngine;

/*
This is meant to handle transitions between different states like jumping, attacking, falling, etc by using an enum
To learn about enums go here - https://www.youtube.com/watch?v=_kDuTk3qeAc
*/
public enum PlayerState
{
    Grounded,
    Attacking,
    Jumping,
    Falling,
}

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerStateMachine : MonoBehaviour
{
    [Header ("Action Scripts")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerJump playerJump;
    [SerializeField] PlayerAttack playerAttack;
    
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
        if (CurrentState != PlayerState.Attacking)
        {
            playerMovement.Move();
            playerJump.Jump();
        }
        else
        {
            playerAttack.Attack();
        }
        


        if (groundChecker.isGrounded && Mathf.Abs(playerRigidbody.velocity.y) < 5)
        {
            CurrentState = playerAttack.isAttacking ? PlayerState.Attacking : PlayerState.Grounded;
        }
        else 
        {
            if (playerJump.jumpButtonDown && CurrentState == PlayerState.Grounded)
            {
                CurrentState = PlayerState.Jumping;
            }
            else if (playerRigidbody.velocity.y < -5) 
            {
                CurrentState = PlayerState.Falling;
            }
        }

    }
}
