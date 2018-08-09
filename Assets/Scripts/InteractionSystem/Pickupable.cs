using UnityEngine;
using UnityEngine.UI;



public class Pickupable : Interactable
{
    private new void Awake()
    {
        base.Awake();

        this.AbleToPickUp = true;
        this.ButtonToInteract = "Left Click";
    }


    public override void ShowInteractHUD(GameObject _textObj)
    {
        _textObj.GetComponent<Text>().text
            = "Press " + ButtonToInteract + " to Pickup";
        _textObj.SetActive(true);
    }

}
