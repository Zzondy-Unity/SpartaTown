using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private Text dialogTxt;

    public bool isAction;

    private GameObject scanObject;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            scanObject = ScanManager.Instance.Scan(transform.position);
            if(scanObject != null)
            {
                Action(scanObject);
            }
            else Debug.Log("오브젝트가 null입니다.");
        }
    }

    public void Action(GameObject scanObj)
    {
        if (isAction)
        {
            dialogPanel.SetActive(false);
            isAction = false;
        }
        else
        {
            dialogPanel.SetActive(true);
            isAction = true;
            scanObject = scanObj;
            dialogTxt.text = scanObject.name;
        }
        dialogPanel.SetActive(isAction);
    }
}