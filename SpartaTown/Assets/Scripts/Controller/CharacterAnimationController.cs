using System;
using UnityEngine;

public class CharacterAnimationController : AnimationController
{
    private static readonly int isWalk = Animator.StringToHash("isWalk");

    private readonly float magnitutueThreshold = 0.5f;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 vector)
    {
        animator.SetBool(isWalk, vector.magnitude > magnitutueThreshold);
    }
}