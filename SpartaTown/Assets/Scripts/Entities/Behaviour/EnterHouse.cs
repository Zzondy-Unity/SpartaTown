using UnityEngine;

public class EnterHouse : MonoBehaviour
{
    [SerializeField] private GameObject QuestMark;

    private void Start()
    {
        QuestMark.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnterBoxCatHouse"))
        {
            QuestMark.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnterBoxCatHouse"))
        {
            QuestMark.SetActive(false);
        }
    }

}