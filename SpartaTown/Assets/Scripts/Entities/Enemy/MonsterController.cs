using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : TopDownController
{
    //캐릭터방향으로 이동
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

    //원거리를 위해
    public float DistanceToTarget()
    {
        return Vector2.Distance(Target.position, transform.position);
    }

    public Vector2 DirectionToTarget()
    {
        return (Target.position - transform.position).normalized;
    }
}
