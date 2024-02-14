using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }

    protected CharacterStatsHandler Stats { get; private set; }

    protected virtual void Awake()
    {
        Stats = GetComponent<CharacterStatsHandler>();
    }

    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (Stats.CurrentStates.attackSO == null) return;

        if(_timeSinceLastAttack <= Stats.CurrentStates.attackSO.delay) // 0.2초의 딜레이
        {
            _timeSinceLastAttack += Time.deltaTime;
        }
        
        if(IsAttacking && _timeSinceLastAttack > Stats.CurrentStates.attackSO.delay)
        {
            _timeSinceLastAttack = 0f;
            CallAttackEvent(Stats.CurrentStates.attackSO);
        }
    }

    public void CallMoveEvnet(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
    
    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }


    // 플레이어가 보물상자와 충돌 시 보물상자 사라지는 기능
    private void OnCollisionEnter2D(Collision2D itemBoxOpen)
    {
        if (itemBoxOpen.gameObject.tag == "ItemBox")
        {
            Destroy(itemBoxOpen.gameObject);
        }
    }
}
