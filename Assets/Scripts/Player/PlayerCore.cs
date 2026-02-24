using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(InputManager))]

public class PlayerCore : SMCore
{
    // Blackboard components
    [HideInInspector] public new Rigidbody2D rigidbody;
    [HideInInspector] public Animator animator;
    [HideInInspector] public InputManager input;

    [HideInInspector] public GroundChecker groundChecker;
    [HideInInspector] public new Transform transform;

    // Player controller objects
    private HorizontalMovementController horizontalMovementController;

    // States
    [Header("Player States")]
    public IdleState idle;
    public RunState run;

    // Player control variables
    [Header("Player Properties")]

    public RunProperties runProperties = new RunProperties();

    protected override void Awake()
    {
        // Fetch components from hierarchy
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        input = GetComponent<InputManager>();

        groundChecker = GetComponentInChildren<GroundChecker>();
        transform = GetComponent<Transform>();

        // Instantiate non-component objects
        horizontalMovementController = new HorizontalMovementController(this);

        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        horizontalMovementController.MoveX
        (
            input.horizontalInput, runProperties.maxRunSpeed,
            runProperties.acceleration, runProperties.deceleration,
            runProperties.velocityPower, runProperties.runFriction
        );

        FlipSprite();
    }

    private void FlipSprite()
    {
        if (Mathf.Abs(input.horizontalInput) > Mathf.Epsilon)
        {
            transform.localScale = new Vector2(Mathf.Sign(input.horizontalInput), 1);
        }
    }
}


