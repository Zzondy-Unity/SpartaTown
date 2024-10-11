using UnityEngine;

public class StatHandler : MonoBehaviour
{
    [SerializeField] Stat baseStat;

    public Stat CurrentStat { get; private set; }
    private CharacterAnimationController controller;
    private HUDController hudController;

    public float currentHP;

    private void Awake()
    {
        UpdateCharacterStat();
        if (CompareTag("Player"))
        {
            controller = GetComponentInChildren<CharacterAnimationController>();
            hudController = GetComponent<HUDController>();
        }
    }

    private void UpdateCharacterStat()
    {
        AttackSO attackSO = null;
        if (baseStat.attackSO != null)
        {
            attackSO = Instantiate(baseStat.attackSO);
        }

        CurrentStat = new Stat { attackSO = attackSO };

        CurrentStat.maxHP = baseStat.maxHP;
        CurrentStat.speed = baseStat.speed;

        currentHP = CurrentStat.maxHP;
    }

    public void ChangeName(string newName)
    {
        Debug.Log(newName);
        if (newName == null) return;
        else
        {
            GameManager.Instance.userName = newName;
            hudController.ChnageName(newName);
        }
    }

    public void ChangeNewJobID(int newJobID)
    {
        if(newJobID == -1) return;
        else
        GameManager.Instance.jobId = newJobID;
        controller.CharacterAnimation(newJobID);
    }
}