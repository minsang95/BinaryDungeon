using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "longDistanceAttackSO", menuName = "Controller/Attack/longDistance", order = 1)]
public class LongDistanceAttackData : AttackSO
{
    [Header("Long Distance Attack Data")]
    public string bulletNameTag;
    public float duration;
    public float spread;
    public int numberOfProjectilesPershot;
    public float multipleProjectilesAngle;
    //public Color projectileColor; // �ʱ� ���� �����ϰ� �Ǿ� �����Ƿ� �� Ȯ��
}
