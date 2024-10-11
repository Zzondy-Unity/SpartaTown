using System;
using UnityEngine;

public class DestroyOnDeath : MonoBehaviour
{
    HealthSystem healthSystem;
    Rigidbody2D rgbody;
    Animator animator;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        rgbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        healthSystem.OnDeath += DestroyThisObject;
    }

    private void DestroyThisObject()
    {
        rgbody.velocity = Vector3.zero;

        //���Ϳ��� �׾��� ���� �ִϸ��̼�
        animator.SetBool("isDead", true);

        //���� �ð� �� �Ⱥ��̰�
        Invoke("Disappear", 5f);
    }

    private void Disappear()
    {
        gameObject.SetActive(false);
    }
}