using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStateMachine))]
public class PlayerGravityHandler : MonoBehaviour
{
    [Header ("Gravity Settings")]
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] float fallGravityScale;
    [SerializeField] float defaultGravityScale;

    // Reference to state machine
    PlayerStateMachine stateMachine;

    void Start()
    {
        // Gets state machine
        stateMachine = GetComponent<PlayerStateMachine>();
    }
    
    // Adjusts gravity based on y velocity
    void FixedUpdate()
    {
        if (stateMachine.CurrentState == PlayerState.Falling)
        {
            playerRigidbody.gravityScale = fallGravityScale;
        }
        else
        {
            playerRigidbody.gravityScale = defaultGravityScale;
        }
    }   
}
