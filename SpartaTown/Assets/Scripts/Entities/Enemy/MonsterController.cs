using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.sceneLoaded += OnSceneLoaded;
        SetTarget();
    }

    private void SetTarget()
    {
        Debug.Log($"{gameManager}, {gameManager.Player}");
        if (gameManager != null && gameManager.Player != null)
        {
            Target = gameManager.Player.transform;
        }
        else Debug.Log("타겟 셋 실패");

    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        SetTarget();
    }

    //원거리를 위해
    public float DistanceToTarget()
    {
        return Vector2.Distance(Target.position, transform.position);
    }

    public Vector2 DirectionToTarget()
    {
        if(Target == null)
        {
            Debug.Log("타겟이 없다.");
        }
        Debug.Log($"타겟 포지션 : { Target.position} / 스크립트위치{ transform.position}");
        return (Target.position - transform.position).normalized;
    }
}
