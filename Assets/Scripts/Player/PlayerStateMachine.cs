using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [Header ("Action Scripts")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerJump playerJump;
    
    [Header ("Sensors")]
    [SerializeField] GroundChecker groundChecker;

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMovement.Move();
        playerJump.Jump();
    }
}
