using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    
    private PlayerInputController controller;
    private Rigidbody2D rgbody;
    private PlayerStatHandler statHandler;
    private PlayerAction playerAction;

    private Vector2 movementdirection = Vector2.zero;

    private void Awake()
    {
        controller = GetComponent<PlayerInputController>();
        rgbody = GetComponent<Rigidbody2D>();
        statHandler = GetComponent<PlayerStatHandler>();
        playerAction = GetComponent<PlayerAction>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        if(playerAction.isAction || uiManager.isMenu)
        {
            rgbody.velocity = Vector2.zero;
        }
        else
        {
            ApplyMoveDirection(movementdirection);
        }
    }

    public void Move(Vector2 direction)
    {
        movementdirection = direction;

        //float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //spriteRenderer.flipX = MathF.Abs(rotZ) > 90;      //움직이는방향보다 내 에임방향이 좋을 것 같다.
    }

    private void ApplyMoveDirection(Vector2 direction)
    {
        direction = direction * statHandler.CurrentStat.speed;

        rgbody.velocity = direction;
    }
}