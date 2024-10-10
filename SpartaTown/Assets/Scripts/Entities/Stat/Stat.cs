

using System;
using UnityEngine;

[System.Serializable]

public class Stat
{
    [Header("PlayStat")]

    public string name;
    [Range(1, 20f)] public float speed;
    [Range(1, 100f)] public float maxHP;
}