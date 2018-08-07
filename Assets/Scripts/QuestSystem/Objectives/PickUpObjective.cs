using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjective : Objective
{
    private GameObject PickUpObject { get; set; }



    public PickUpObjective(Quest quest, GameObject pickUpObj, string description)
    {
        this.Description = description;
        this.PickUpObject = pickUpObj;
    }

    public override void Init()
    {
        base.Init();


    }

}
