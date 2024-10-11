using System;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    private TopDownController controller;
    private SpriteRenderer SpriteRenderer;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        controller.OnLookEvent += Look;
    }

    private void Look(Vector2 vector)
    {
        //�� ���� �� ���콺�� �ִ� ������ ���͸� normalized�� ���� �޾Ҵ�.
        float rotZ = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        SpriteRenderer.flipX = Mathf.Abs(rotZ) > 90;
    }
}