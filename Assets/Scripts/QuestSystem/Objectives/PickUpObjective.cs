using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjective : Objective
{
    private GameObject TargetObject { get; set; }
    private string targetName { get; set; }

    public PickUpObjective(QuestBase quest, string _name, string _description,
        int pickupAmount = 1)
    {
        this.Quest = quest;
        this.Description = _description;
        this.targetName = _name;
        this.TotalCount = pickupAmount;
        this.CurrentCount = 0;
    }

    public override void Init()
    {
        base.Init();

        TargetObject = GameObject.Find(targetName);
        if (TargetObject == null)
        {
            TargetObject = Spawner.Instance.SpawnItemOnDesk(targetName);
        }

        // Start listen to the player grabbing event
        PlayerGrabbing.OnPlayerPickUp.AddListener(this.CheckPickUp);
    }

    // Exist as a event trigger function
    private void CheckPickUp(GameObject pickuppedObj)
    {
        if (pickuppedObj == TargetObject && !Compeleted)
        {
            Debug.Log("Pickup notified");
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
