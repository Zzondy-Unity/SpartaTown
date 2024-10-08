using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private PlayerInputController controller;
    private Rigidbody2D rgbody;

    private Vector2 movementdirection = Vector2.zero;

    private void Awake()
    {
        controller = GetComponent<PlayerInputController>();
        rgbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMoveDirection(movementdirection);
    }

    private void Move(Vector2 direction)
    {
        movementdirection = direction;

        //float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //spriteRenderer.flipX = MathF.Abs(rotZ) > 90;      //움직이는방향보다 내 에임방향이 좋을 것 같다.
    }

    private void ApplyMoveDirection(Vector2 direction)
    {
        direction = direction * 5;

        rgbody.velocity = direction;
    }
}