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

    //�߻���ġ, ȸ����, ��������
    public void ShootBullet(Vector2 startPosition, Vector2 direction, LongDistanceAttackData attackData)
    {
        GameObject obj = Instantiate(testObj);
        obj.transform.position = startPosition;
        
        LongDistanceAttackController attackController = obj.GetComponent<LongDistanceAttackController>();
        attackController.InitializeAttack(direction, attackData, this); 

        obj.SetActive(true);
    }
}
