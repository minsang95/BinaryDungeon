using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapperOnDeath : MonoBehaviour
{
    [SerializeField] private GameObject[] Keys;
    private int keyIndex;
    private HealthSystem _healthSystem;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        keyIndex = Random.Range(0, Keys.Length);
        _healthSystem = GetComponent<HealthSystem>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _healthSystem.OnDeath += OnDeath;
    }

    void OnDeath()
    {
        _rigidbody.velocity = Vector3.zero;

        GameObject key = Instantiate(Keys[keyIndex]);
        key.transform.position = transform.position;

        foreach(SpriteRenderer renderer in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            Color color = renderer.color;
            color.a = 0.3f;
            renderer.color = color;
        }

        foreach (Behaviour component in transform.GetComponentsInChildren<Behaviour>())
        {
            component.enabled = false;
        }

        Destroy(gameObject, 2f);
    }
}
