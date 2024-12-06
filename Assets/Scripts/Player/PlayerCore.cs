using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInputManager))]
public class PlayerCore : SMCore
{
    // Components for states
    [HideInInspector] public new Rigidbody2D rigidbody;
    [HideInInspector] public Animator animator;
    [HideInInspector] public PlayerInputManager input;

    // Sensors for state transitions
    [Header ("Sensors")]
    [SerializeField] public GroundChecker groundChecker;
    
    [Header ("Properties")]
    public float runSpeed;
    
    // States
    [Header ("States")]
    public IdleState idleState;
    public RunState runState;
    public JumpState jumpState;
    public AttackState attackState;
    public AirState airState;

    public bool canMoveX {get; set;}
    public bool isGrounded => groundChecker.IsGrounded;
   
    protected override void Awake()
    {
        // Gets components
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        input = GetComponent<PlayerInputManager>();      
        base.Awake();
    }

    protected override void Start()
    {
        canMoveX = true; // Enables movement on start
        rigidbody.gravityScale = 6; // Sets gravity scale
        base.Start();
    }

    private void Update()
    {   // If the state machine isnt already transitioning states, then check for next state
        if (!stateMachine.isTransitioning)
        {
            stateMachine.EvaluateStateTransition(state); // Inherited from SMCore
        }
        state.StateUpdateHierarchy(); // Runs the update method on the current state
    }

    private void FixedUpdate()
    {
        // If movement enabled then character moves based on input from PlayerInputManager
        if (canMoveX)
        {
            HandleXMovement(input.AxisInput);
        }
        
        // Runs state fixed update method if state machine isnt transitioning
        if (!stateMachine.isTransitioning)
        {
            state.StateFixedUpdateHierarchy();
        }
    }

    // Handles X movement
    private void HandleXMovement(Vector2 movement)
    {
        rigidbody.velocity = new Vector2(movement.x * runSpeed, rigidbody.velocity.y);

        if (Mathf.Abs(movement.x) > Mathf.Epsilon)
        {
            transform.localScale = new Vector2(Mathf.Sign(movement.x), 1);
        }
    }
}
