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
        dialogData.Add(1001, NPC_B);    //�����ʾƷ� �ҳ�
        dialogData.Add(100, new string[] { "�����̴�. ���ſ��� �ű� ���� ����." });   //�׳� ������
    }

    static readonly string[] NPC_A = new string[]
    {
        "�ȳ�?",
        ("{userName}? Ư���� �̸��̳�"),
        "���� ��ó�� ����ٰ� �����ϸ� �ȵ���",
        "���ݺ��� ���ʿ� �ִ� �����̵��� ���ʶ߸��ž�.",
        "�ʴ� ����ΰ��� �������� ������"
    };

    static readonly string[] NPC_B = new string[]
    {
        "�ȳ�",
        "��.. �� ����",
        "���̸�? �˰ž��ݾ� ���� ��"
    };


    public static string GetDialogs(int NpcId, int dialogIndex)
    {
        if (dialogIndex >= dialogData[NpcId].Length)
            return null;
        else
            return dialogData[NpcId][dialogIndex].Replace("{userName}", GameManager.Instance.userName);
    }
}