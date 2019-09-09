using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : MonoBehaviour
{
    //This script is to give npcs quests, the script can be accessed
    //dia a dialog system to call diffewrent effects

    GameObject player;
    QuestScriptPlayer quests;

    public string questname = "";
    private void Start()
    {
        GameObject player = GameObject.Find("PlayerController");
        QuestScriptPlayer quests = player.GetComponent<QuestScriptPlayer>();
    }
    public bool checkQuest()
    {
        return quests.CheckForQuest(name);
    }
    public void GiveQuest()
    {
        quests.AddQuest(questname);
    }
    public void setStage(int stage)
    {
        quests.SetQuestStage(name, stage);
    }
    public int getStage()
    {
        int i = quests.GetStage(name);
        if (i == -1)        
            Debug.LogError(this.gameObject + "with the quest "+ name + " Quest tried to access the player quests without the player having the quest");
        return i;
    }


}
