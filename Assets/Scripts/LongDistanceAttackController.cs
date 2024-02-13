using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongDistanceAttackController : MonoBehaviour
{
    [SerializeField] private LayerMask mapCollisionLayer;

    private LongDistanceAttackData _attackData;
    private float _currentDuration;
    private Vector2 _direction;
    private bool _isReady;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRanderer;
    private TrailRenderer _trailRenderer;
    private ProjectileManager _projectileManager;


    private void Awake()
    {
        _spriteRanderer = GetComponentInChildren<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if(_isReady) return;

        _currentDuration += Time.deltaTime;

        if(_currentDuration > _attackData.duration)
        {
            DestoryProjectile(transform.position);
        }
        _rigidbody.velocity = _direction * _attackData.speed;

    }
    //충돌
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(mapCollisionLayer.value == (mapCollisionLayer.value | 1 << collision.gameObject.layer))
        {
            DestoryProjectile(collision.ClosestPoint(transform.position) - _direction * 0.2f);
        }
    }

    //초기화
    public void InitializeAttack(Vector2 direction, LongDistanceAttackData attackData,ProjectileManager projectileManager)
    {
        _projectileManager = projectileManager;
        _attackData = attackData;
        _direction = direction;

        UpdateProjectileSprite();
        _trailRenderer.Clear();
        _currentDuration = 0;
        _spriteRanderer.color = attackData.projectileColor;

        // x축(플레이어의 오른쪽) 방향을 direction으로 날아가게
        transform.right = _direction;

        _isReady = true;
    }

    private void UpdateProjectileSprite()
    {
        transform.localScale = Vector3.one * _attackData.size;
    }

    private void DestoryProjectile(Vector3 position)
    {
        gameObject.SetActive(false);
    }
}
