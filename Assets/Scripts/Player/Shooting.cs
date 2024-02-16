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
        _projectileManager = ProjectileManager.instance; //안써주면 nullReference 발생..
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 aim)
    {
        _aimDirection = aim; //조준 방향 업데이트
    }

    private void OnShoot(AttackSO attackSO)
    {
        LongDistanceAttackData longDistanceAttackData = attackSO as LongDistanceAttackData; //형변환
        float projectilesAngleSpace = longDistanceAttackData.multipleProjectilesAngle;
        int numberOfProjectilesPerShot = longDistanceAttackData.numberOfProjectilesPershot;

        // 각도 조절 
        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * longDistanceAttackData.multipleProjectilesAngle;

        for(int i = 0; i < numberOfProjectilesPerShot; i++) // 총알 갯수
        {
            float angle = minAngle + projectilesAngleSpace * i; //총알과 총알의 사이 각도
            float randomSpread = Random.Range(-longDistanceAttackData.spread, longDistanceAttackData.spread);
            angle += randomSpread; //랜덤으로 퍼짐 설정
            CreateProjectile(longDistanceAttackData,angle);
        }
        
    }

    private void CreateProjectile(LongDistanceAttackData longDistanceAttackData, float angle)
    {
        _projectileManager.ShootBullet(projectileSpawnPosition.position,//발사위치
            RotateVector2(_aimDirection, angle), //발사각
            longDistanceAttackData); // 공격 정보
    }

    private static Vector2 RotateVector2(Vector2 vector, float degree) //회전각 (2D벡터 회전)
    {
        return Quaternion.Euler(0,0,degree)* vector;
    }
}
