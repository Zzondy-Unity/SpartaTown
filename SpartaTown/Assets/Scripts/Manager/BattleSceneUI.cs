using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSceneUI : MonoBehaviour
{
    GameObject battleSceneUI;

    private void Awake()
    {
        battleSceneUI = GameObject.FindGameObjectWithTag("UI");
        battleSceneUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0.0f;
            battleSceneUI.SetActive(true);
        }
    }

    public void OnExitBtnClicked()
    {
        SceneManager.LoadScene("TownScene");
        Time.timeScale = 1.0f;
    }
}
