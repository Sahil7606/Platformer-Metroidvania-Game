using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public enum AttackState
{
    Startup, // State before sword is swung
    Active, // State while sword is being swung and hitbox is active
    Recovery, // State where player is recovering
}

[RequireComponent(typeof(TraversalStateMachine))]
public class AttackStateMachine : MonoBehaviour
{
    // Reference to traversal state machine
    TraversalStateMachine tStateMachine;
    [HideInInspector] public bool attackButtonDown;
    private Dictionary<TraversalState, Type> attackForState; // Dictionary pairs the corresponding attack for each traversal state
    private PlayerAttack currentAttack;

    void Awake()
    {
        tStateMachine = GetComponent<TraversalStateMachine>();

        attackForState = new Dictionary<TraversalState, Type>()
        {
            {TraversalState.Idle, typeof(BasicAttack)},
            {TraversalState.Walking, typeof(BasicAttack)}
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    void OnAttack()
    {   
        attackButtonDown = true;
    }
}
