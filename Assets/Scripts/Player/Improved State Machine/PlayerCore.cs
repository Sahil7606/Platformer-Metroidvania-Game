using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(InputManager))]
public class PlayerCore : SMCore
{
    [HideInInspector] public new Rigidbody2D rigidbody;
    [HideInInspector] public Animator animator;
    [HideInInspector] public InputManager input;
}
