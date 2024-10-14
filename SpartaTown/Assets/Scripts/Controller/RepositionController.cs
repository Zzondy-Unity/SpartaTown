using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RepositionController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private PlayerInputController controller;
    private Vector2 MoveDirection;

    private void Awake()
    {
        controller = player.GetComponent<PlayerInputController>();
    }

    private void Start()
    {
        controller.OnMoveEvent += inputDirection;
    }

    public void inputDirection(Vector2 direction)
    {
        MoveDirection = direction;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        {
            return;
        }

        Vector3 playerPos = player.transform.position;
        Vector3 myPos = transform.position;

        float dirX = playerPos.x - myPos.x;
        float dirY = playerPos.y - myPos.y;

        float diffX = Mathf.Abs(dirX) / 36;
        float diffY = Mathf.Abs(dirY) / 20;

        dirX = dirX > 0 ? 1 : -1;
        dirY = dirY > 0 ? 1 : -1;

        switch (transform.tag)
        {
            case "Ground" :
                if(diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 72);
                }
                else if(diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;
            case "Enemy":

                break;

        }

    }
}
