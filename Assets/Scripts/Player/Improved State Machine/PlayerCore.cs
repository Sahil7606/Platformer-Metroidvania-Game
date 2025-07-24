using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(InputManager))]
public class PlayerCore : SMCore
{
    // Blackboard components
    [HideInInspector] public new Rigidbody2D rigidbody;
    [HideInInspector] public Animator animator;
    [HideInInspector] public InputManager input;

    // States
    [Header("Player States")]
    public IdleState idle;
    public RunState run;

    // Player control variables
    public float horizontalMoveSpeed = 5;

    protected override void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        input = GetComponent<InputManager>();

        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        HandleHorizontalMovement();
    }

    private void HandleHorizontalMovement()
    {
        rigidbody.linearVelocityX = input.horizontalInput * horizontalMoveSpeed * Time.fixedDeltaTime;
    }

    private void FlipSprite()
    {
        throw new NotImplementedException();
    }
}
