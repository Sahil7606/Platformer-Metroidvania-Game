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
        Min Jump height is about 1.5 units


IMPLEMENT LATER:
    Particle effect on landing
    Coyote Time
    Slight camera shake
    Jump Attacks

*/

public class Player_Jump : MonoBehaviour
{
    [Header ("Components")]

    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] GroundChecker groundChecker;
    [SerializeField] Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(groundChecker.isGrounded);
    }

    void OnJump(InputValue jumpButton)
    {
        if (jumpButton.isPressed)
        {
            playerRigidbody.velocity += new Vector2(0, 5);
        }
    }
}
