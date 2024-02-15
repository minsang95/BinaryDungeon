using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LongDistanceAttackController : MonoBehaviour
{
    [SerializeField] private LayerMask mapCollisionLayer;

    private LongDistanceAttackData _attackData;
    private float _currentDuration; // �߻�ü ���� �� ��� �ð�
    private Vector2 _direction; // �߻�ü ����
    private bool _isReady;// �߻�ü �غ�

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRanderer;
    private TrailRenderer _trailRenderer;
    private ProjectileManager _projectileManager;

    public bool fxOnDestroy = true;

    private BossHead bossHead;


    private void Awake()
    {
        _spriteRanderer = GetComponentInChildren<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _trailRenderer = GetComponent<TrailRenderer>();
    }
    private void Update()
    {
        if (!_isReady) //false�� �� return
        {
            return;
        }
        else
        {
            _currentDuration += Time.deltaTime;

            if (_currentDuration > _attackData.duration)
            {
                DestroyProjectile(transform.position, false);
            }
            _rigidbody.velocity = _direction * _attackData.speed; //�߻�ü ���ư���(�ӵ�)
        }
       

    }
    //�浹
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (mapCollisionLayer.value == (mapCollisionLayer.value | 1 << collision.gameObject.layer))
        {
            DestroyProjectile(collision.ClosestPoint(transform.position) - _direction * .2f, fxOnDestroy);
        }
        else if(_attackData.target.value == (_attackData.target.value | (1 << collision.gameObject.layer)))
        {
            HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
            if(healthSystem != null)
            {
                healthSystem.ChangeHealth(-_attackData.power);
                if(_attackData.isOnKnockback)
                {
                    Movement movement = collision.GetComponent<Movement>();
                    if(movement != null)
                    {
                        movement.ApplyKnockback(transform, _attackData.knockbackPower, _attackData.knockbackTime);
                    }
                }
            }
            DestroyProjectile(collision.ClosestPoint(transform.position) - _direction * .2f, fxOnDestroy);
        }

        if (collision.CompareTag("Boss"))
        {
            bossHead = collision.GetComponent<BossHead>();
            bossHead.bossHP -= _attackData.power;
            bossHead.bossHP = bossHead.bossHP < 0 ? 0 : bossHead.bossHP;           
            Debug.Log($"BossHP : {bossHead.bossHP}");
            gameObject.SetActive(false);
        }
    }

    //�ʱ�ȭ
    public void InitializeAttack(Vector2 direction, LongDistanceAttackData attackData,ProjectileManager projectileManager)
    {
        _projectileManager = projectileManager;
        _attackData = attackData;
        _direction = direction;

        UpdateProjectileSprite();
        _trailRenderer.Clear();
        _currentDuration = 0;
        //_spriteRanderer.color = attackData.projectileColor;

        // x��(�÷��̾��� ������) ������ direction���� ���ư���
        transform.right = _direction;

        _isReady = true;
    }

    private void UpdateProjectileSprite()
    {
        transform.localScale = Vector3.one * _attackData.size;
    }

    private void DestroyProjectile(Vector3 position, bool createFx)
    {
        if (createFx)
        {

        }
        gameObject.SetActive(false);
    }
}
