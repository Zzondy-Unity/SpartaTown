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
            //������ �� ��ġ�� �����صΰ� ����ġ�� �� ������ ���� �ִ°����� ���� �ε巯�� ȸ��
            CallLookEvent(Vector2.Lerp(previousAim, newAim, 0.5f));
            previousAim = newAim;
        }
    }

    public void OnAttack(InputValue value)
    {
        //����
        CallAttackEvent();
    }

}
