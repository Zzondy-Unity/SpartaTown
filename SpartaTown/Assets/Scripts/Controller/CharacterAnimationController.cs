using System;
using UnityEngine;

public class CharacterAnimationController : AnimationController
{
    //아직 왜 StringToHsh를 해야하는지는 아직 모르겠다.
    private static readonly int isWalk = Animator.StringToHash("isWalk");

    private readonly float magnitutueThreshold = 0.5f;

    public RuntimeAnimatorController[] animCon;

    protected override void Awake()
    {
        base.Awake();
    }

    protected void OnEnable()
    {
        CharacterAnimation(GameManager.Instance.jobId);
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 vector)
    {
        if(this.CompareTag("Player"))
        animator.SetBool(isWalk, vector.magnitude > magnitutueThreshold);
    }

    public void CharacterAnimation(int jobId)
    {
        animator.runtimeAnimatorController = animCon[jobId];
    }
}