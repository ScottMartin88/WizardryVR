using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScriptPlayer : MonoBehaviour
{

    public List<Quest> Quests;
    GameObject QuestHolder;

    void Start()
    {
        //Setting the object that will hold all the quests
        QuestHolder = GameObject.Find("QuestHolder");
    }


    //This method is to add the quest. after adding the quest the name will be null
    //We can use this to find the null quest and set the quest with a name and set
    //its stage(quest progress to 0)
    public void AddQuest(string Name)
    {
        Quests.Add(QuestHolder.AddComponent<Quest>());

        for (int i = 0; i < Quests.Count; i++)
        {
            if (Quests[i].GetName() == null)
            {
                Quests[i].SetQuest(name);
                break;
            }
        }
    }


    //This sets the stage of the quest. which can be used to allow different dialog
    //or different things around the world to instantiate depending on the quest stage
    public void SetQuestStage(string Name, int Stage)
    {
        for (int i = 0; i < Quests.Count; i++)
        {
            if (Quests[i].GetName() == Name)
            {
                Quests[i].SetStage(Stage);
                break;
            }
        }
    }

    //can be used to check if a quest is already recieved, using this before adding 
    //a new quest can be used to stoip doubles and errors.
    /*
     For instance ask npc for quest:
     checks for quest
     if true:
     doesnt give the quest 
     if false:
     calls the add quest method
     */
    public bool CheckForQuest(string name)
    {
        for (int i = 0; i < Quests.Count; i++)
        {
            if (Quests[i].GetName() == name)
            {
                return true;
            }
        }
        return false;
    }

    public int GetStage(string name)
    {
        for (int i = 0; i < Quests.Count; i++)
        {
            if (Quests[i].GetName() == name)
            {
                return Quests[i].GetStage();
            }
        }
        return -1;
    }

}