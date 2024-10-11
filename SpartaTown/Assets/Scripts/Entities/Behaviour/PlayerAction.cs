using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private Text dialogTxt;

    public int dialogIndex = 0;
    public GameObject scaned;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject scanObject = ScanManager.Instance.Scan(transform.position);
            if (scanObject != null)
            {
                Action(scanObject);
            }
            else Debug.Log("오브젝트가 null입니다.");
        }
    }

    public void Action(GameObject scanObj)
    {
        scaned = scanObj;
        ObjData objData = scanObj.GetComponentInParent<ObjData>();

        if (objData != null)
            Talk(objData.id, objData.isNpc);

        dialogPanel.SetActive(GameManager.Instance.isAction);
    }

    public void Talk(int id, bool isNpc)
    {
        string dialog = DialogManager.GetDialogs(id, dialogIndex);

        if (dialog == null)
        {
            GameManager.Instance.isAction = false;
            dialogIndex = 0;
            return;
        }

        if (isNpc)
        {
            dialogTxt.text = dialog;
        }
        else
        {
            dialogTxt.text = "말을하지않는물체";
        }
        GameManager.Instance.isAction = true;
        dialogIndex++;
    }
}