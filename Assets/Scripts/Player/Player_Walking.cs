using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;

public class Player_Walking : MonoBehaviour
{
    [Header ("Components")] 
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] Animator playerAnimator;

    [Header ("Walk Properties")]
    public float speed;

    [HideInInspector] public Vector2 MoveInput;

    void FixedUpdate()
    {
        Move();
    }

    // Uses Input system to detect movement input
    void OnMove(InputValue input)
    {
        MoveInput = input.Get<Vector2>();
    }

    // This makes the player actually move
    void Move()
    {
        playerRigidbody.velocity = new Vector2(MoveInput.x * speed, playerRigidbody.velocity.y);

        // Flips player sprite based on direction if moving
        if (Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon) // Epsilon is a number very close to 0. Gets rid of floating point inaccuracies
        {
            transform.localScale = new Vector2(MoveInput.x, 1);
        }
    }
}
