using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintQuest : QuestBase
{
	void Start ()
    {
        QuestName = "Print Something";
        Descrition = "Go print some thing for me";
        RewardScore = 100;
        PunishScore = 50;

        Objectives.Add(new PickUpObjective(this, "Cube", "Pick up a cube pls~"));
    }
	
}
