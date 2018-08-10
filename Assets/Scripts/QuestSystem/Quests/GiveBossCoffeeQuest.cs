using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveBossCoffeeQuest : QuestBase
{
    private void Start()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        QuestName = "Boss: Bring me a coffee";
        this.gameObject.name = QuestName;
        Description = "Go get a coffee for me!";
        QuestTime = 30.0f;
        RewardScore = 100;
        PunishScore = 50;

        base.Initialize();

        Objectives.Add(new PickUpObjective(this, "Coffee", "Pick up a coffee"));
        Objectives.Add(new DropZoneObjective(this, "BossDropZone", "Give it to the boss"));

        foreach (Objective objective in Objectives)
        {
            objective.Init();
        }
    }

}
