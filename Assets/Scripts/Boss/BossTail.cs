using UnityEngine;

public class BossTail : BossBase
{
    [SerializeField] private Rigidbody2D targetRigidbody;
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        SpawnMucus();
        switch (BossHead.i.tailP)
        {
            case 0:
            case 1:
            case 2:
                speed = BossHead.i.speed;
                _direction = DirectionToTarget();
                ApplyMovement(_direction);
                break;
            case 3:
                _rigidbody.velocity = Vector3.zero;
                speed = 24f;
                if (BossHead.i.changeTime > 7.6f)
                {
                    _direction = -_direction;
                }
                break;
            case 4:
                ApplyMovement(_direction);
                speed -= Time.fixedDeltaTime * 16f;
                if (speed < 0) speed = 0;
                break;
        }

        Rotate(_direction);
        SetSortingOrder();
    }
    protected override Vector2 DirectionToTarget()
    {
        return ((Vector2)ClosestTarget.position - (targetRigidbody.velocity.normalized) * 0.6f - (Vector2)transform.position).normalized;
    }
}
