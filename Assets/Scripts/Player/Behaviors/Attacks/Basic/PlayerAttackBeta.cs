using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum AttackState
{
    start,
    active,
    recovery,
    complete
}
public class PlayerAttackBeta : MonoBehaviour
{
    [SerializeField] List<Attack> combo;
    Attack currentAttack;
    int currentAttackIndex;
    TraversalStateMachine stateMachine;
    Rigidbody2D rb2d;
    bool isAttacking;
    bool attackButtonDown;
    public AttackState state {get; private set;}
    Coroutine frameDataSM;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        state = AttackState.complete;
        animator = GetComponent<Animator>();
        stateMachine = GetComponent<TraversalStateMachine>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Attack();
    }

    void OnAttack()
    {
        // Returns if player can't attack
        if (!stateMachine.canAttack || state == AttackState.start || attackButtonDown) { return; }

        if (state == AttackState.complete)
        {
            currentAttackIndex = 0;
        }
        else if (state == AttackState.active || state == AttackState.recovery)
        {
            currentAttackIndex++;
            if (currentAttackIndex == combo.Count)
            {
                currentAttackIndex = 0;
            }
        }

        attackButtonDown = true;     
    }

    void Attack()
    {
        switch (state)
        {
            case AttackState.start:
                break;
            case AttackState.active:
                break;
            case AttackState.recovery:
                CheckForAttack();
                break;
            case AttackState.complete:
                CheckForAttack();
                break;
        }
    }

    void CheckForAttack()
    {
        if (attackButtonDown)
        {
            attackButtonDown = false;
            StopAllCoroutines();
            currentAttack = combo[currentAttackIndex];
            animator.SetTrigger($"Attack{currentAttackIndex}");
            frameDataSM = StartCoroutine(FrameDataTracker());
        }
    }

    IEnumerator FrameDataTracker()
    {
        stateMachine.enabled = false;
        rb2d.velocity = Vector2.zero;
        isAttacking = true;

        state = AttackState.start;
        yield return new WaitForSeconds(currentAttack.startupFrames / currentAttack.animation.frameRate);

        state = AttackState.active;
        yield return new WaitForSeconds(currentAttack.activeFrames / currentAttack.animation.frameRate);
        
        state = AttackState.recovery;
        yield return new WaitForSeconds(currentAttack.recoveryFrames / currentAttack.animation.frameRate);
 
        isAttacking = false;
        stateMachine.enabled = true;
        state = AttackState.complete;
        Debug.Log("Attack Complete");
    }
}
