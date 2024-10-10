using System;
using UnityEngine;

public class CharacterAnimationController : AnimationController
{
    private static readonly int isWalk = Animator.StringToHash("isWalk");

    private readonly float magnitutueThreshold = 0.5f;

    //플레이어 정보에다가 나중에 다시 쓸 예정
    public RuntimeAnimatorController[] animCon;

    protected override void Awake()
    {
        base.Awake();
    }

    protected void OnEnable()
    {
        animator.runtimeAnimatorController = animCon[GameManager.Instance.jobId];
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