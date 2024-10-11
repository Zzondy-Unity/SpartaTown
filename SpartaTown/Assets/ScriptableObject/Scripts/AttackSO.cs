using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "DefaultAttackSO", menuName = "AttackSO/DefalutAttackSO", order = 0)]
public class AttackSO : ScriptableObject
{
    [Header("basic propoties")]
    [SerializeField]
    private int weaponId;
    public int WeaponId { get { return weaponId; } }

    [SerializeField]
    private string weaponName;
    public string WeaponName { get { return weaponName; } }

    [SerializeField]
    private float attackPower;
    public float AttackPower { get { return attackPower; } }

    [SerializeField]
    private float attackSpeed;
    public float AttackSpeed { get { return attackSpeed; } }

}
