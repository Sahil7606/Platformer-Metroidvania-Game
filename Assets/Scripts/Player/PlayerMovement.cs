using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerStateMachine))]
public class PlayerMovement : MonoBehaviour
{
    [Header ("Components")] 
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] Animator playerAnimator;

    [Header ("Walk Properties")]
    public float speed;

    [HideInInspector] public Vector2 MoveInput;

    // Reference to player state machine
    PlayerStateMachine stateMachine;

    void Start()
    {
        // Gets the state machine
        stateMachine = GetComponent<PlayerStateMachine>();
    }

    // Uses Input system to detect movement input
    void OnMove(InputValue input)
    {
        MoveInput = input.Get<Vector2>();
    }

    // This makes the player actually move
    public void Move()
    {
        playerRigidbody.velocity = new Vector2(MoveInput.x * speed, playerRigidbody.velocity.y);

        // Flips player sprite based on direction if moving
        if (Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon) // Epsilon is a number very close to 0. Gets rid of floating point inaccuracies
        {
            playerAnimator.SetBool("IsWalking", true);
            transform.localScale = new Vector2(MoveInput.x, 1);
        }
        else
        {
            playerAnimator.SetBool("IsWalking", false);
        }
    }

}
