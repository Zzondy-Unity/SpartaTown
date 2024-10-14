using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MeleeWeaponController : MonoBehaviour
{
    [SerializeField] private GameObject Melee;

    public int numberOfMelee = 1;
    public float radius = 1.0f;
    public float angularSpeed = 1.0f;


    private void Update()
    {
        CircleMove();
    }

    //내 주위를 회전하는 물건
    //Vector의 Rotate함수 활용할 예정
    private void CircleMove()
    {
        float angleStep = 360 / numberOfMelee;
        float angle = 0;

        for (int i = 0; i < numberOfMelee; i++)
        {
            float projectileDirX = transform.position.x + Mathf.Sin(angle);
            float projectileDirY = transform.position.y + Mathf.Cos(angle);

            Vector3 projectileVector = new Vector3(projectileDirX, projectileDirY, 0);
            Vector2 projectileMoveDirection = (projectileVector - transform.position).normalized * angularSpeed;

            GameObject tmpObj = Instantiate(Melee, transform.position, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

            angle += angleStep;
        }

    }
}