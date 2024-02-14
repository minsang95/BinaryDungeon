using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 _aimDirection = Vector2.right;

    private ProjectileManager _projectileManager;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _projectileManager = ProjectileManager.instance; //�Ƚ��ָ� nullReference �߻�..
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 aim)
    {
        _aimDirection = aim; //���� ���� ������Ʈ
    }

    private void OnShoot(AttackSO attackSO)
    {
        LongDistanceAttackData longDistanceAttackData = attackSO as LongDistanceAttackData; //����ȯ
        float projectilesAngleSpace = longDistanceAttackData.multipleProjectilesAngle;
        int numberOfProjectilesPerShot = longDistanceAttackData.numberOfProjectilesPershot;

        // ���� ���� 
        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * longDistanceAttackData.multipleProjectilesAngle;

        for(int i = 0; i < numberOfProjectilesPerShot; i++) // �Ѿ� ����
        {
            float angle = minAngle + projectilesAngleSpace * i; //�Ѿ˰� �Ѿ��� ���� ����
            float randomSpread = Random.Range(-longDistanceAttackData.spread, longDistanceAttackData.spread);
            angle += randomSpread; //�������� ���� ����
            CreateProjectile(longDistanceAttackData,angle);
        }
        
    }

    private void CreateProjectile(LongDistanceAttackData longDistanceAttackData, float angle)
    {
        _projectileManager.ShootBullet(projectileSpawnPosition.position,//�߻���ġ
            RotateVector2(_aimDirection, angle), //�߻簢
            longDistanceAttackData); // ���� ����
    }

    private static Vector2 RotateVector2(Vector2 vector, float degree) //ȸ���� (2D���� ȸ��)
    {
        return Quaternion.Euler(0,0,degree)* vector;
    }
}
