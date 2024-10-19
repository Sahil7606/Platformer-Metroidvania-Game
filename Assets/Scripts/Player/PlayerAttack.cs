using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerStateMachine))]
public class PlayerAttack : MonoBehaviour
{
    [Header ("Components")]
    [SerializeField] Rigidbody2D playerRigid;
    [SerializeField] Animator playerAnimator;

    [HideInInspector] public bool isAttacking;
    private float comboTimer;
    private bool nextAttackQueued;
    private int nextAttackNumber = 0;
    private bool attackButtonDown;

    PlayerStateMachine stateMachine;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<PlayerStateMachine>();
    }

    void FixedUpdate()
    {
        if (stateMachine.CurrentState == PlayerState.Attacking)
        {
            comboTimer += Time.fixedDeltaTime;
        }
    }

    void OnBasicAttack(InputValue attackButton)
    {
        if (stateMachine.CurrentState == PlayerState.Grounded)
        {
            isAttacking = true;
            nextAttackNumber = 0;
        }
        else if (stateMachine.CurrentState == PlayerState.Attacking && comboTimer < 0.5)
        {
            nextAttackNumber++;
        }

        attackButtonDown = true;
        comboTimer = 0;
    }

    public void Attack()
    {
        if (comboTimer >= 0.5)
        {
            comboTimer = 0;
            isAttacking = false;
        }
        
        if (attackButtonDown)
        {
            switch (nextAttackNumber)
            {
                case 0:
                    playerAnimator.SetTrigger("BasicAttack0");
                    break;
                case 1:
                    playerAnimator.SetTrigger("BasicAttack1");
                    break;
                case 2:
                    playerAnimator.SetTrigger("BasicAttack2");
                    attackButtonDown = false;
                    isAttacking = false;
                    break;
            }

            attackButtonDown = false;
        }
    }
}
