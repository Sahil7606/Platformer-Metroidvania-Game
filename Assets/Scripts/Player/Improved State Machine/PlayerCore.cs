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

    [HideInInspector] public new Transform transform;

    // States
    [Header("Player States")]
    public IdleState idle;
    public RunState run;

    // Player control variables
    [Header("Player Properties")]
    public float horizontalMoveSpeed;

    protected override void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        input = GetComponent<InputManager>();

        transform = GetComponent<Transform>();

        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        HandleHorizontalMovement();
        FlipSprite();
    }

    private void HandleHorizontalMovement()
    {
        rigidbody.linearVelocityX = input.horizontalInput * horizontalMoveSpeed;
    }

    private void FlipSprite()
    {
        if (Mathf.Abs(input.horizontalInput) > Mathf.Epsilon)
        {
            transform.localScale = new Vector2(Mathf.Sign(input.horizontalInput), 1);
        }
    }
}
