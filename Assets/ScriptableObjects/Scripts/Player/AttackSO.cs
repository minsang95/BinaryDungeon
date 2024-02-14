using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "closeDistanceAttackSO", menuName = "Controller/Attack/closeDistance", order = 0)]
public class AttackSO : ScriptableObject
{
    [Header("Attack Info")]
    public float size;
    public float delay;
    public float power;
    public float speed;
    public LayerMask target; // ÀûÁßÅ¸°Ù

    //³Ë¹é ±¸Çö
    [Header("Knock Back Info")]
    public bool isOnKnockback;
    public float knockbackPower;
    public float knockbackTime;
}

