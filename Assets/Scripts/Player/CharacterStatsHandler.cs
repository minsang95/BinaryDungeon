using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField] private CharacterStats baseStats;
    
    public CharacterStats CurrentStates { get; set; }
    public List<CharacterStats> statsModifiers = new List<CharacterStats>();

    private void Awake()
    {
        UpdateStats();
    }
    private void Update()
    {
        if(CurrentStates._timeSinceLastChange < CurrentStates.healthChangeDelay)
            CurrentStates._timeSinceLastChange += Time.deltaTime;
    }
    private void UpdateStats()
    {
        AttackSO attackSO = null;
        if(baseStats.attackSO != null)
        {
            attackSO = Instantiate(baseStats.attackSO);
        }

        CurrentStates = new CharacterStats { attackSO = attackSO };

        CurrentStates.Type = baseStats.Type;
        CurrentStates.maxHealth = baseStats.maxHealth;
        CurrentStates.speed = baseStats.speed;
    }
}
