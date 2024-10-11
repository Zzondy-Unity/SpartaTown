using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : TopDownController
{
    //ĳ���͹������� �̵�
    GameManager gameManager;
    protected Transform Target { get; private set; }


    protected override void Awake()
    {
        base.Awake();
    }
    protected virtual void Start()
    {
        gameManager = GameManager.Instance;
        Target = gameManager.Player.transform;
    }

    //���Ÿ��� ����
    public float DistanceToTarget()
    {
        return Vector2.Distance(Target.position, transform.position);
    }

    public Vector2 DirectionToTarget()
    {
        return (Target.position - transform.position).normalized;
    }
}
