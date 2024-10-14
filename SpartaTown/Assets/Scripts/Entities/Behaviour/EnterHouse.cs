using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHouse : MonoBehaviour
{
    [SerializeField] private GameObject QuestMark;
    PlayerAction playerAction;

    private void Awake()
    {
        playerAction = GetComponent<PlayerAction>();
    }

    private void Update()
    {
        if (GameManager.Instance.CommunicatedWithBoxCat == true)
        {
            Destroy(QuestMark);
            Destroy(GameObject.FindWithTag("Stone_left"));
        }
    }

    private void Start()
    {
        QuestMark.SetActive(false);
        playerAction.OnTalkToBoxCat += QuestAccept;
    }

    private void QuestAccept()
    {
        GameManager.Instance.CommunicatedWithBoxCat = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnterBattle"))
        {
            SceneManager.LoadScene("BattleScene");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnterBoxCatHouse") && QuestMark)
        {
            QuestMark.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnterBoxCatHouse"))
        {
            if (QuestMark)
                QuestMark.SetActive(false);
        }
    }

}