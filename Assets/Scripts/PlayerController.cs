using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterController
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 move = value.Get<Vector2>().normalized;
        CallMoveEvnet(move);
    }

    public void OnLook(InputValue value)
    {
        Vector2 look = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(look);
        look = (worldPos - (Vector2)transform.position).normalized;

        if(look.magnitude >= 0.9f)
        {
            CallLookEvent(look);
        }
    }

}
