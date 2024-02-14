using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Movement : MonoBehaviour
{
    private MoveCharacterController _controller;
    private Monster_CharacterStatsHandler _stats;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _controller = GetComponent<MoveCharacterController>();
        _stats = GetComponent<Monster_CharacterStatsHandler>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * _stats.CurrentStates.speed;
        _rigidbody.velocity = direction;
    }
}
