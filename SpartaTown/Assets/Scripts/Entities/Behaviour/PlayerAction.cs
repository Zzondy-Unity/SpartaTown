using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private Text dialogTxt;

    public GameObject scaned;
    private int dialogIndex = 0;

    public event Action OnTalkToBoxCat;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject scanObject = ScanManager.Instance.Scan(transform.position);
            if (scanObject != null)
            {
                Action(scanObject);
            }
        }
    }

    public void Action(GameObject scanObj)
    {
        scaned = scanObj;
        ObjData objData = scaned.GetComponentInParent<ObjData>();

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
            if(id == 1000)
            {
                OnTalkToBoxCat?.Invoke();
            }
        }
        else
        {
            dialogTxt.text = "말을하지않는물체";
        }
        GameManager.Instance.isAction = true;
        dialogIndex++;
    }
}