using System;
using System.Collections.Generic;
using UnityEngine;

public static class DialogManager
{
    public static Dictionary<int, string[]> dialogData;

    static DialogManager()
    {
        dialogData = new Dictionary<int, string[]>();
        GenerateData();
    }


    private static void GenerateData()
    {
        dialogData.Add(1000, NPC_A);    //boxCat
        dialogData.Add(1001, NPC_B);    //오른쪽아래 소녀
        dialogData.Add(100, new string[] { "돌맹이다. 무거워서 옮길 수가 없다." });   //그냥 돌맹이
    }

    static readonly string[] NPC_A = new string[]
    {
        "안녕?",
        ("{userName}? 특이한 이름이네"),
        "내가 돌처럼 생겼다고 무시하면 안되지",
        "지금부터 서쪽에 있는 돌덩이들을 무너뜨릴거야.",
        "너는 저기로가서 괴물들을 무찔러줘"
    };

    static readonly string[] NPC_B = new string[]
    {
        "안녕",
        "음.. 어 가봐",
        "내이름? 알거없잖아 빨리 가"
    };


    public static string GetDialogs(int NpcId, int dialogIndex)
    {
        if (dialogIndex >= dialogData[NpcId].Length)
            return null;
        else
            return dialogData[NpcId][dialogIndex].Replace("{userName}", GameManager.Instance.userName);
    }
}