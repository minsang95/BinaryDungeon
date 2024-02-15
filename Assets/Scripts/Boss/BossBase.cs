using UnityEngine;

public class BossBase : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer characterRenderer;
    [SerializeField] protected Transform[] otherBodys;
    [SerializeField] protected GameObject mucus;
    [SerializeField] protected Transform ClosestTarget;

    protected Rigidbody2D _rigidbody;
    protected Vector3 _direction;
    protected bool outFloor = false;
    protected float mucusSpawnTime;

    [HideInInspector] public float speed = 8f;
    [HideInInspector] public int damage = 1;

    protected HealthSystem playerHealthSystem;
    protected Movement playerMovement;
    protected bool isCollidingWithPlayer = false;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        if (isCollidingWithPlayer)
        {
            playerHealthSystem.ChangeHealth(damage);
            playerMovement.ApplyKnockback(transform, 20f, 0.1f);
        }
    }

    protected void ApplyMovement(Vector2 direction)
    {
        direction = direction * speed;
        _rigidbody.velocity = direction;
    }
    protected float DistanceToTarget()
    {
        return Vector3.Distance(transform.position, ClosestTarget.position);
    }
    protected virtual Vector2 DirectionToTarget()
    {
        return (ClosestTarget.position - transform.position).normalized;
    }
    protected void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0, 0, rotZ);
        characterRenderer.flipY = Mathf.Abs(rotZ) > 90f;
    }

    protected void SetSortingOrder()
    {
        characterRenderer.sortingOrder = 6;
        for (int i = 0; i < otherBodys.Length; i++)
        {
            if (otherBodys[i].position.y > transform.position.y)
            {
                characterRenderer.sortingOrder++;
            }
        }
    }

    protected void SpawnMucus()
    {
        mucusSpawnTime += Time.fixedDeltaTime;
        if (mucusSpawnTime > 0.15f)
        {
            GameObject go = GameManager.Instance.objectPool.SpawnFromPool("Mucus");
            go.transform.position = transform.position;
            go.SetActive(true);
            mucusSpawnTime = 0f;
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
            outFloor = false;
        if (!outFloor)
        {
            if (collision.CompareTag("GroundV"))
            {
                _direction.y = -_direction.y;
            }
            else if (collision.CompareTag("GroundH"))
            {
                _direction.x = -_direction.x;
            }
        }

        if (collision.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            playerHealthSystem = player.GetComponent<HealthSystem>();
            playerMovement = player.GetComponent<Movement>();
            isCollidingWithPlayer = true;
        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
            outFloor = true;

        isCollidingWithPlayer = false;
    }
}
