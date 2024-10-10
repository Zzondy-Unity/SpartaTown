using UnityEngine;

public class PlayerStatHandler : MonoBehaviour
{
    [SerializeField] Stat baseStat;

    public Stat CurrentStat { get; private set; }
    private CharacterAnimationController controller;
    private HUDController hudController;


    private void Awake()
    {
        UpdateCharacterStat();
        controller = GetComponentInChildren<CharacterAnimationController>();
        hudController = GetComponent<HUDController>();
    }

    private void UpdateCharacterStat()
    {
        CurrentStat = new Stat();

        CurrentStat.name = GameManager.Instance.userName;
        CurrentStat.jobId = GameManager.Instance.jobId;
        CurrentStat.maxHP = baseStat.maxHP;
        CurrentStat.speed = baseStat.speed;
    }

    public void ChangeName(string newName)
    {
        if (newName == null) return;
        else
            CurrentStat.name = newName;
        GameManager.Instance.name = newName;
        hudController.ChnageName(newName);
    }

    public void ChangeNewJobID(int newJobID)
    {
        if(newJobID == -1) return;
        else
            CurrentStat.jobId = newJobID;
        GameManager.Instance.jobId = newJobID;
        controller.CharacterAnimation(newJobID);
    }
}