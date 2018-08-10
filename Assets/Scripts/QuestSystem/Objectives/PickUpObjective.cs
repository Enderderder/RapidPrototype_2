using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjective : Objective
{
    private GameObject TargetObject { get; set; }
    private string TargetName { get; set; }

    public PickUpObjective(QuestBase quest, string _name, string _description,
        int pickupAmount = 1)
    {
        this.Quest = quest;
        this.Description = _description;
        this.TargetName = _name;
        this.TotalCount = pickupAmount;
        this.CurrentCount = 0;
    }

    ~PickUpObjective()
    {
        // Stop listen to the player grabbing event
        PlayerGrabbing.OnPlayerPickUp.RemoveListener(this.CheckPickUp);
    }

    public override void Init()
    {
        base.Init();

        TargetObject = GameObject.Find(TargetName);
        if (TargetObject == null)
        {
            TargetObject = Spawner.Instance.SpawnItemOnDesk(TargetName);
        }

        // Start listen to the player grabbing event
        PlayerGrabbing.OnPlayerPickUp.AddListener(this.CheckPickUp);
    }

    // Exist as a event trigger function
    private void CheckPickUp(GameObject pickuppedObj)
    {
        if (pickuppedObj == TargetObject && !Compeleted)
        {
            this.CurrentCount++;
            this.Evaluate();
        }

        if (Compeleted)
        {
            // Stop listen to the player grabbing event
            PlayerGrabbing.OnPlayerPickUp.RemoveListener(this.CheckPickUp);
        }
    }
}
