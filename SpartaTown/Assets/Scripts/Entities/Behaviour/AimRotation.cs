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
        //내 기준 내 마우스가 있는 방향의 벡터를 normalized한 값을 받았다.
        float rotZ = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        SpriteRenderer.flipX = Mathf.Abs(rotZ) > 90;
    }
}