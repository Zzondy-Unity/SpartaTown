using UnityEngine;

public class StatHandler : MonoBehaviour
{
    [SerializeField] Stat baseStat;

    public Stat CurrentStat { get; private set; }

    private void Awake()
    {
        UpdateCharacterStat();
    }

    private void UpdateCharacterStat()
    {
        CurrentStat = new Stat();

        CurrentStat.name = GameManager.Instance.name;
        CurrentStat.maxHP = baseStat.maxHP;
        CurrentStat.speed = baseStat.speed;
    }


}