using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    private Text nameText;
    private string playerName;

    private void Awake()
    {
        nameText = GetComponentInChildren<Text>();
    }

    private void Start()
    {
        playerName = GameManager.Instance.userName;
        nameText.text = playerName;
    }
}