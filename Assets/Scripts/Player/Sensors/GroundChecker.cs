using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [HideInInspector] public bool isGrounded;

    LayerMask ground;

    // Ground Layer
    void Start()
    {
        ground = LayerMask.NameToLayer("Ground");
    }

    // Sets bool to true when trigger is touching ground
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == ground)
        {
            isGrounded = true;
        }
    }

    // Sets bool to false when trigger leaves ground
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == ground)
        {
            isGrounded = false;
        }
    }
}
