using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour
{

    [SerializeField] private BossHead bossHead;
    private Rigidbody2D bossRigidbody;

    private void Awake()
    {
        bossRigidbody = bossHead.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (bossHead.bossHP == 0)
        {
            Death();
            bossHead.currentHpText.text = "0";
            GameManager.Instance.GameClear();
        }
    }

    void Death()
    {
        bossRigidbody.velocity = Vector3.zero;

        foreach (SpriteRenderer renderer in transform.GetComponentsInChildren<SpriteRenderer>())
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
