using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(TraversalStateMachine))]
public class PlayerMovement : MonoBehaviour
{
    [Header ("Components")] 
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] Animator playerAnimator;

    [Header ("Walk Properties")]
    public float speed;

    [HideInInspector] public Vector2 MoveInput;

    // Reference to player state machine
    TraversalStateMachine stateMachine;

    private void Start()
    {
        // Gets the state machine
        stateMachine = GetComponent<TraversalStateMachine>();
    }

    // Uses Input system to detect movement input
    void OnMove(InputValue input)
    {
        MoveInput = input.Get<Vector2>();
    }

    // This makes the player actually move
    public void Move()
    {
        playerRigidbody.linearVelocity = new Vector2(MoveInput.x * speed, playerRigidbody.linearVelocity.y);

        // Flips player sprite based on direction if moving
        if (Mathf.Abs(playerRigidbody.linearVelocity.x) > Mathf.Epsilon) // Epsilon is a number very close to 0. Gets rid of floating point inaccuracies
        {
            transform.localScale = new Vector2(Mathf.Sign(MoveInput.x), 1);
        }

        PlayWalkAnim();        
    }

    void PlayWalkAnim()
    {
        if (stateMachine.traversalState == TraversalState.Walking)
        {
            playerAnimator.SetBool("IsWalking", true);
        }
        else
        {
            playerAnimator.SetBool("IsWalking", false);
        }
    }

}
