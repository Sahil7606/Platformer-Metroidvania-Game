using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TraversalStateMachine))]
public class PlayerGravityHandler : MonoBehaviour
{
    [Header ("Gravity Settings")]
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] float fallGravityScale;
    [SerializeField] float defaultGravityScale;

    // Reference to state machine
    TraversalStateMachine stateMachine;

    void Start()
    {
        // Gets state machine
        stateMachine = GetComponent<TraversalStateMachine>();
    }
    
    // Adjusts gravity based on y velocity
    void FixedUpdate()
    {
        if (stateMachine.traversalState == TraversalState.Falling)
        {
            playerRigidbody.gravityScale = fallGravityScale;
        }
        else
        {
            playerRigidbody.gravityScale = defaultGravityScale;
        }
    }   
}
