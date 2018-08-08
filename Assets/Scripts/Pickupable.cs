using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : Interactable
{
    private new void Awake()
    {
        base.Awake();

        this.AbleToPickUp = true;
        this.ButtonToInteract = "Fire1";
    }

}
