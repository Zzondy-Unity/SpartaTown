using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    private Camera _camera;
    private Vector2 previousAim = Vector2.zero;
    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);

    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        if(newAim.magnitude >= .9f)
        {
            //에임의 전 위치를 지정해두고 현위치와 그 절반의 값을 주는것으로 좀더 부드러운 회전
            CallLookEvent(Vector2.Lerp(previousAim, newAim, 0.5f));
            previousAim = newAim;
        }
    }

    public void OnAttack(InputValue value)
    {
        //공격
        CallAttackEvent();
    }

}
