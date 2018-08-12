using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringTheCoffee : QuestBase
{
    void Start()
    {
        QuestName = "Bring Coffee";
        Description = "Bring a hot coffee to the boss.";
        QuestTime = 30.0f;
        RewardScore = 100;
        PunishScore = 50;

        Objectives.Add(new PickUpObjective(this, "Coffee", "Pick up a cube pls~"));
        Objectives.Add(new DropZoneObjective(this, "BossDeskDropZone", "Dropthecoffe to the boss."));

        foreach (Objective objective in Objectives)
        {
            objective.Init();
        }
    }
}
