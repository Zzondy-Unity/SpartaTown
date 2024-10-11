using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    private Text nameText;
    private string playerName;
    private Slider HPbar;
    private StatHandler playerStatHandler;

    private void Awake()
    {
        playerStatHandler = GetComponent<StatHandler>();
        nameText = GetComponentInChildren<Text>();
        HPbar = GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        HPbar.value = playerStatHandler.CurrentStat.maxHP / playerStatHandler.currentHP;
    }

    private void Start()
    {
        playerName = GameManager.Instance.userName;
        ChnageName(playerName);
    }

    public void ChnageName(string newName)
    {
        playerName = newName;
        nameText.text = newName;
    }
}