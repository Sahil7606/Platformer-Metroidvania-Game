using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
Jump Full Implementation Details

MUST HAVES:
    Attacks are stored in scriptable objects
    Player does a basic 3 attack combo
    Damage increases with each attack in combo
    Frame data system to keep track of windup, swing, and recovery

IMPLEMENT LATER:
    Jump attacks
    Slam down attack
*/
[RequireComponent(typeof(TraversalStateMachine))]
public class PlayerAttack : MonoBehaviour
{
    [Header ("Components")]
    [SerializeField] Rigidbody2D playerRigid;
    [SerializeField] Animator playerAnimator;

    [SerializeField] Attack[] basicCombo = new Attack[3];

    [HideInInspector] public bool isAttacking;
    private bool attackButtonDown;
    TraversalStateMachine stateMachine;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<TraversalStateMachine>();
    }

    void OnBasicAttack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
        }

        attackButtonDown = true;
    }

    public void Attack()
    {
        if (attackButtonDown)
        {

        }
    }

    
}
