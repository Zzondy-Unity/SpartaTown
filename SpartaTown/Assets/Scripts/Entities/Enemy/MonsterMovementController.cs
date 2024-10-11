using System;
using UnityEngine;

public class MonsterMovementController : MonsterController
{
    //플레이어 방향과 거리를 전달받는다
    //해당 몬스터의 스펙을 받는다
    private TopDownController controller;
    private Rigidbody2D rgbody;
    private SpriteRenderer spriteRenderer;
    private StatHandler statHandler;

    private float distance;
    private Vector2 direction;


    protected override void Awake()
    {
        base.Awake();
        controller = GetComponent<TopDownController>();
        rgbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        statHandler = GetComponent<StatHandler>();
    }

    protected void FixedUpdate()
    {
        direction = DirectionToTarget();
        distance = DistanceToTarget();

        RangeAttackSO rangeAttackSO = statHandler.CurrentStat.attackSO as RangeAttackSO;
        if(rangeAttackSO != null && distance <= rangeAttackSO.AttackRange)
        {
            CallMoveEvent(Vector2.zero);
            Debug.Log("목표를 포착했다.");
        }
        else
        {
            Flip(direction);
            direction = direction * statHandler.CurrentStat.speed;
            CallMoveEvent(direction);
        }
    }


    private void Flip(Vector2 vector)
    {
        float rotZ = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        spriteRenderer.flipX = Mathf.Abs(rotZ) > 90;
    }
}