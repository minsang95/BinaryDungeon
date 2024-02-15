using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

enum Pattern
{
    Idle,
    P1,
    P2,
    P3,
    P4,
}

public class BossHead : BossBase
{
    Pattern pattern = Pattern.Idle;
    private bool changePattern = false;
    [HideInInspector] public float changeTime = 0;

    private float deg = 0;

    public static BossHead i;
    [HideInInspector] public int tailP = 0;

    public float bossHP = 20;

    public TextMeshProUGUI currentHpText;
    public TextMeshProUGUI maxHpText;

    protected override void Awake()
    {
        base.Awake();
        i = this;
        _direction = ClosestTarget.transform.position;
    }

    private void Update()
    {
        currentHpText.text = Convert.ToString((int)bossHP, 2);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        SpawnMucus();
        changeTime += Time.fixedDeltaTime;
        if (changePattern)
        {
            switch (Random.Range(0, 4))
            {
                case 1: pattern = Pattern.P1; break;
                case 2: pattern = Pattern.P2; break;
                case 3: pattern = Pattern.P3; break;
            }
        }
        switch (pattern)
        {
            case Pattern.Idle:
                changePattern = false;
                tailP = 0;
                _direction = DirectionToTarget();
                ApplyMovement(_direction);
                if (changeTime > 4) changePattern = true;
                break;
            case Pattern.P1:
                changePattern = false;
                tailP = 1;
                _direction = Coiled(-265f);
                ApplyMovement(_direction);
                speed -= Time.fixedDeltaTime * 2f;
                if (changeTime > 6.6f)
                {
                    speed = 8f;
                    _direction = (ClosestTarget.position - transform.position).normalized;
                    pattern = Pattern.Idle;
                    changeTime = 2f;
                }
                break;
            case Pattern.P2:
                changePattern = false;
                tailP = 2;
                _direction = Coiled(265f);
                ApplyMovement(_direction);
                speed -= Time.fixedDeltaTime * 2f;
                if (changeTime > 7.1f)
                {
                    _direction = (ClosestTarget.position - transform.position).normalized;
                    StartCoroutine(Rush());
                    pattern = Pattern.Idle;
                    changeTime = 0;
                }
                break;
            case Pattern.P3:
                changePattern = false;
                if (changeTime < 6.6f)
                {
                    _direction = Coiled(265f);
                    ApplyMovement(_direction);
                    speed -= Time.fixedDeltaTime * 2f;
                }
                else
                {
                    tailP = 3;
                    _rigidbody.velocity = Vector3.zero;
                    speed = 0f;
                    if (changeTime > 7f)
                    {
                        _direction = transform.position.normalized;
                        pattern = Pattern.P4;
                    }
                }
                break;
            case Pattern.P4:
                tailP = 4;
                if (speed < 6f)
                {
                    ApplyMovement(_direction);
                    speed += Time.fixedDeltaTime * 4f;
                }
                else
                {
                    speed = 8f;
                    pattern = Pattern.Idle;
                    changeTime = 0;
                    tailP = 0;
                }
                break;
        }

        Rotate(_direction);
        SetSortingOrder();
    }

    protected override Vector2 DirectionToTarget()
    {
        return (_direction + ((ClosestTarget.position - transform.position).normalized * 0.05f)).normalized;
    }

    protected Vector2 Coiled(float speed)
    {
        if (deg > 360) deg = 0;
        var rad = (deg) * Mathf.Deg2Rad;
        var x = Mathf.Sin(rad);
        var y = Mathf.Cos(rad);
        deg += Time.fixedDeltaTime * speed;
        return new Vector2(x, y).normalized;
    }

    IEnumerator Rush()
    {
        speed = 16f;
        yield return new WaitForSeconds(1f);
        speed = 8f;
    }
}
