using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapperOnDeath : MonoBehaviour
{
    private int keyIndex;
    private HealthSystem _healthSystem;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _healthSystem.OnDeath += OnDeath;
    }
    private void Update()
    {
        keyIndex = Random.Range(0, GameManager.Instance.Keys.Count);
    }
    void OnDeath()
    {
        _rigidbody.velocity = Vector3.zero;

        GameObject key = Instantiate(GameManager.Instance.Keys[keyIndex]);
        if(GameManager.Instance.Keys.Count > 1)
        {
            GameManager.Instance.Keys.RemoveAt(keyIndex);
        }
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
