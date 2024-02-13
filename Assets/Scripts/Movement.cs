using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _controller;
    private Rigidbody2D _rigidbody;
    private CharacterStatsHandler _stats;

    private Vector2 _movement = Vector2.zero;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _stats = GetComponent<CharacterStatsHandler>();
    }

    void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movement);
    }

    private void Move(Vector2 direction)
    {
        _movement = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * _stats.CurrentStates.speed;

        _rigidbody.velocity = direction;
    }

}