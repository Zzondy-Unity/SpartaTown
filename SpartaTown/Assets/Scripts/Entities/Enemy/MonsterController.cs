using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.sceneLoaded += OnSceneLoaded;
        SetTarget();
    }

    private void SetTarget()
    {
        if (gameManager != null && gameManager.Player != null)
        {
            Target = gameManager.Player.transform;
        }

    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        SetTarget();
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
