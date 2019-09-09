using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField]
    private string questName;
    [SerializeField]
    private int questStage;

    public string GetName()
    {
        return questName;
    }
    public int GetStage()
    {
        return questStage;
    }

    public void SetQuest(string name)
    {
        questName = name;
        questStage = 0;
    }

    public void SetName(string Name)
    {
        questName = Name;
    }
    public void SetStage(int stage)
    {
        questStage = stage;
    }
}
