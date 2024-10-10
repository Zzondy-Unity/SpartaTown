using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneController : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private GameObject characterGroup;
    [SerializeField] private GameObject writeNameUI;
    [SerializeField] private GameObject selected;

    private int inputid = 0;
    private string playerName;
    private Animator animator;

    public RuntimeAnimatorController[] animCon;

    private void Awake()
    {
        animator = selected.GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        characterGroup.SetActive(false);
        writeNameUI.SetActive(true);
        selected.SetActive(true);
    }

    public void InputName()
    {
        playerName = inputField.text;
        GoTown();
    }

    public void CharacterSelectedClicked()
    {
        selected.SetActive(false);
        characterGroup.SetActive(true);
    }

    public void OnCharacterSelectBtnsClicked(int id)
    {
        inputid = id;
        animator.runtimeAnimatorController = animCon[inputid];
        characterGroup.SetActive(false);
        selected.SetActive(true);
    }

    private void GoTown()
    {
        GameManager.Instance.GameStart(playerName, inputid);
    }

}