using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZoneObjective : Objective
{
    private GameObject TargetDropZone { get; set; }
    private string TargetName { get; set; }

    public DropZoneObjective(QuestBase quest, string _name, string _description)
    {
        this.Quest = quest;
        this.Description = _description;
        this.TargetName = _name;
        this.TotalCount = 1;
        this.CurrentCount = 0;
    }

    ~DropZoneObjective()
    {
        // Stop listen to the player grabbing event
        PlayerGrabbing.OnPlayerDropZone.RemoveListener(this.CheckDropped);
    }

    public override void Init()
    {
        base.Init();

        TargetDropZone = GameObject.Find(TargetName);

        // Start listen to the player grabbing event
        PlayerGrabbing.OnPlayerDropZone.AddListener(this.CheckDropped);
    }

    private void CheckDropped(GameObject dropZone)
    {
        if (dropZone.name == TargetName && !Compeleted)
        {
            this.CurrentCount++;
            this.Evaluate();
        }

        if (Compeleted)
        {
            // Stop listen to the player grabbing event
            PlayerGrabbing.OnPlayerPickUp.RemoveListener(this.CheckDropped);
        }
    }
}
