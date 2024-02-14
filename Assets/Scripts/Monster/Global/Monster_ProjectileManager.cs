using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_ProjectileManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _impactParticleSystem;

    public static Monster_ProjectileManager instance;

    [SerializeField] private GameObject testObj;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    public void ShootBullet(Vector2 startPostiion, Vector2 direction, RangedAttackData attackData)
    {
        GameObject obj = Instantiate(testObj);

        obj.transform.position = startPostiion;
        RangedAttackController attackController = obj.GetComponent<RangedAttackController>();
        attackController.InitializeAttack(direction, attackData, this);

        obj.SetActive(true);
    }

}