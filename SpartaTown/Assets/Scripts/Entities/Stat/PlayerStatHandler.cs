using UnityEngine;

public class PlayerStatHandler : MonoBehaviour
{
    [SerializeField] Stat baseStat;

    public Stat CurrentStat { get; private set; }

    private void Awake()
    {
        UpdateCharacterStat();
    }

    private void UpdateCharacterStat()
    {
        CurrentStat.name = baseStat.name;
        CurrentStat.maxHP = baseStat.maxHP;
        CurrentStat.speed = baseStat.speed;
    }


}