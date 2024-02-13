using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BossTailController : BossBase
{
    [SerializeField] private Rigidbody2D target;
    private void FixedUpdate()
    {
        SpawnMucus();
        switch (BossController.i.tailP)
        {
            case 0:
            case 1:
            case 2:
                speed = BossController.i.speed;
                _direction = DirectionToTarget();
                ApplyMovement(_direction);
                break;
            case 3:
                _rigidbody.velocity = Vector3.zero;
                speed = 24f;
                if (BossController.i.changeTime > 7.6f)
                {
                    _direction = (transform.position - breakUpPivot.transform.position).normalized;
                }
                break;
            case 4:
                ApplyMovement(_direction);
                speed -= Time.fixedDeltaTime * 16f;
                if (speed < 0) speed = 0;
                break;
        }

        Rotate(_direction);
        characterRenderer.sortingOrder = 6;
        for (int i = 0; i < otherBodys.Length; i++)
        {
            if (otherBodys[i].position.y > transform.position.y)
            {
                characterRenderer.sortingOrder++;
            }
        }
    }
    protected override Vector2 DirectionToTarget()
    {
        return ((Vector2)ClosestTarget.position - (target.velocity.normalized) * 0.6f - (Vector2)transform.position).normalized;
    }
}
