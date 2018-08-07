using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintQuest : QuestBase
{
	void Start ()
    {
        QuestName = "Print Something";
        Description = "Go print some thing for me";
        QuestTime = 30.0f;
        RewardScore = 100;
        PunishScore = 50;

        Objectives.Add(new PickUpObjective(this, "Cube", "Pick up a cube pls~"));

        foreach (Objective objective in Objectives)
        {
            objective.Init();
        }
    }
	
}
