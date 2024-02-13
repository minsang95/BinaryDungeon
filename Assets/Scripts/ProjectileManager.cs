using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
   public static ProjectileManager instance;

    [SerializeField] private GameObject testObj;

    private void Awake()
    {
        instance = this;
    }

    //발사위치, 회전각, 공격정보
    public void ShootBullet(Vector2 startPosition, Vector2 direction, LongDistanceAttackData attackData)
    {
        GameObject obj = Instantiate(testObj);
        obj.transform.position = startPosition;
        
        LongDistanceAttackController attackController = obj.GetComponent<LongDistanceAttackController>();
        attackController.InitializeAttack(direction, attackData, this); 

        obj.SetActive(true);
    }
}
