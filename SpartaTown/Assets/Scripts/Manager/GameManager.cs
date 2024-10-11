using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public Transform Player { get; private set; }

    private Text timetxt;

    public string userName = "";
    public int jobId = 0;
    public bool isMenu = false;
    public bool isAction = false;

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if(instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        if(timetxt != null)
        {
            DateTime now = DateTime.Now;
            timetxt.text = string.Format("{0:D2}:{1:D2}:{2:D2}", now.Hour, now.Minute, now.Second);
        }

        //currenttime += Time.deltaTime;
        //if(timetxt != null)
        //{
        //    TimeSpan time = TimeSpan.FromSeconds(currenttime);
        //    timetxt.text = string.Format("{0:D2}:{1:D2}", time.Minutes, time.Seconds);
        //}
    }


    public void SetTimeTxt(Text newTimeTxt)
    {
        timetxt = newTimeTxt;
    }

    public void GameStart(string playerName, int playerid)
    {
        userName = playerName;
        jobId = playerid;
        SceneManager.LoadScene("TownScene");
    }




}
