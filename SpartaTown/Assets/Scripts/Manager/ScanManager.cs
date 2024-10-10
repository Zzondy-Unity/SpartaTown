using System;
using System.Collections.Generic;
using UnityEngine;

public class ScanManager : MonoBehaviour            //스캔은 전투와 대화 등 너무 많은곳에서 사용할 것 같아서 싱글톤작업
{
    private static ScanManager instance;
    public static ScanManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<ScanManager>();
                if(instance == null)
                {
                    GameObject go = new GameObject("Scanner");
                    instance = go.AddComponent<ScanManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private PlayerInputController controller;
    private Vector2 direction = Vector2.zero;


    private void Awake()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerInputController>();
    }

    private void Start()
    {
        controller.OnLookEvent += ScanDirection;
    }

    private void ScanDirection(Vector2 vector)
    {
        direction = vector;
    }

    //맵 전체(씬) 스캔 -> npc몇명
    public List<GameObject> SceneScanNpc()
    {
        List<GameObject> objs = new List<GameObject>();

        Vector2 pointA = new Vector2(-1920, 540);
        Vector2 pointB = new Vector2(1920, -540);

        Collider2D[] colliders = Physics2D.OverlapAreaAll(pointA, pointB);

        foreach(var collider in colliders)
        {
            if(collider.gameObject.layer == LayerMask.GetMask("NPC"))
            {
                objs.Add(collider.gameObject);
            }
        }

        return objs;
    }

    //내 바로 앞 스캔 -> 대화
    public GameObject Scan(Vector2 origin)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, 1f, LayerMask.GetMask("Npc"));
        Debug.DrawRay(origin, direction, Color.black);
        if(hit.collider == null)
        {
            return null;
        }
        else
        {
            return hit.collider.gameObject;
        }
    }
}