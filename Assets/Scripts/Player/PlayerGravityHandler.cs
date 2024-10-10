using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravityHandler : MonoBehaviour
{
    [Header ("Gravity Settings")]
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] float fallGravityScale;
    [SerializeField] float defaultGravityScale;
    
    // Adjusts gravity based on y velocity
    void FixedUpdate()
    {
        if (playerRigidbody.velocity.y < 0)
        {
            playerRigidbody.gravityScale = fallGravityScale;
        }
        else
        {
            playerRigidbody.gravityScale = defaultGravityScale;
        }
    }   
}
