using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChageType
{
    Add,
    Multiple,
    Override,
}

[Serializable]
public class CharacterStats 
{
    public StatsChageType Type;
    [Range(1, 100)] public int maxHealth;
    [Range(1f, 30f)] public float speed;

    public AttackSO attackSO;
}
