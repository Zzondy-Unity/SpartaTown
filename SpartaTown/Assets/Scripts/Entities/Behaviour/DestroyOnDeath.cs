using System;
using UnityEngine;

public class DestroyOnDeath : MonoBehaviour
{
    HealthSystem healthSystem;
    Rigidbody2D rgbody;
    Animator animator;
    Collider2D col;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        rgbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        col = col.GetComponent<Collider2D>();
    }

    private void Start()
    {
        healthSystem.OnDeath += DestroyThisObject;
    }

    private void DestroyThisObject()
    {
        rgbody.velocity = Vector3.zero;

        //몬스터에게 죽었을 때의 애니메이션
        animator.SetBool("isDead", true);

        //일정 시간 후 안보이게
        Invoke("Disappear", 5f);
    }

    private void Disappear()
    {
        gameObject.SetActive(false);
        col.isTrigger = true; //플레이어와 부딪히지 않고
    }
}