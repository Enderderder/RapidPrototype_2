using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintQuest : QuestBase
{
	private void Start ()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        QuestName = "Print Something";
        this.gameObject.name = QuestName;
        Description = "Go print some thing for me";
        QuestTime = 30.0f;
        RewardScore = 100;
        PunishScore = 50;

        base.Initialize();

        Objectives.Add(new PickUpObjective(this, "Item_test", "Pick up a cube pls~"));

        foreach (Objective objective in Objectives)
        {
            objective.Init();
        }
    }
	
}
