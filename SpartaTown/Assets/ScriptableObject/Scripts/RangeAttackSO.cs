using UnityEngine;

[CreateAssetMenu(fileName = "DefaultAttackSO", menuName = "AttackSO/RangeAttackSO", order = 1)]
public class RangeAttackSO : AttackSO
{
    [Header("Range porperties")]
    [SerializeField]
    private float attackRange;
    public float AttackRange { get { return attackRange; } }

    [SerializeField]
    private float projectileSpeed;
    public float ProjectileSpeed { get { return projectileSpeed; } }

}