using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private Text timeText;

    [Header("Menu")]
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject ChangeName;
    [SerializeField] private GameObject ChangeChar;
    [SerializeField] private GameObject NumOfPeople;
    [SerializeField] private GameObject BackGrounUI;

    [Header("ChangeName")]
    [SerializeField] private GameObject writeNameUI;
    [SerializeField] private InputField inputField;

    [Header("ChangeChar")]
    [SerializeField] private GameObject characterGroup;
    [SerializeField] private GameObject selected;
    [SerializeField] private RuntimeAnimatorController[] animCon;

    [Header("CheckPeople")]
    [SerializeField] private Text currentPeople;
    [SerializeField] private GameObject backGround;

    private Animator menuAnimator;
    private Animator characterAnimator;
    private PlayerStatHandler statHandler;

    private int newJobId = -1;
    private string newName = "";
    private int checkPeople;
    public bool isMenu = false;

    private List<GameObject> selectedNpcs;


    private void Awake()
    {
        menuAnimator = MenuPanel.GetComponent<Animator>();
        characterAnimator = selected.GetComponentInChildren<Animator>();
        statHandler = GameObject.Find("Player").GetComponent<PlayerStatHandler>();
    }

    private void Start()
    {
        GameManager.Instance.SetTimeTxt(timeText);
        ChangeName.SetActive(false);
        ChangeChar.SetActive(false);
        NumOfPeople.SetActive(false);
        writeNameUI.SetActive(false);
        selected.SetActive(false);
    }



    public void OnMenuClicked()
    {
        if(isMenu == false)
        {
            isMenu = true;
            BackGrounUI.SetActive(true);
            menuAnimator.SetBool("isOpen", true);
        }
        else
        {
            isMenu = false;
            BackGrounUI.SetActive(false);
            menuAnimator.SetBool("isOpen", false);
        }
    }

    public void OnChangeNameClicked()
    {
        ChangeName.SetActive(true);     
        writeNameUI.SetActive(true);
    }

    public void InputName()
    {
        newName = inputField.text;
        OnOKBtnClicked();
    }

    public void OnChangeCharClicked()
    {
        ChangeChar.SetActive(true);
        selected.SetActive(true);
    }

    public void OnSelectedClicked()
    {
        selected.SetActive(false);
        characterGroup.SetActive(true);
    }

    public void OnCharacterSelectBtnClicked(int index)
    {
        newJobId = index;
        characterAnimator.runtimeAnimatorController = animCon[newJobId];
        statHandler.ChangeNewJobID(newJobId);
        characterGroup.SetActive(false);
        selected.SetActive(true);

    }

    public void OnPeopleCheckCliced()
    {
        //현재 이곳에 있는 npc의 숫자
        selectedNpcs = ScanManager.Instance.SceneScanNpc();
        checkPeople = selectedNpcs.Count;
        currentPeople.text = checkPeople.ToString() + "명";
        backGround.SetActive(true);
    }

    public void OnOKBtnClicked()
    {
        BackGrounUI.SetActive(false);
        menuAnimator.SetBool("isOpen", false);
        statHandler.ChangeName(newName);
        ChangeName.SetActive(false);
        ChangeChar.SetActive(false);
        NumOfPeople.SetActive(false);
        writeNameUI.SetActive(false);
        selected.SetActive(false);
        backGround.SetActive(false);
        isMenu = false;
    }

}