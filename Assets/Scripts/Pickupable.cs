public class Pickupable : Interactable
{
    private new void Awake()
    {
        base.Awake();

        this.AbleToPickUp = true;
        this.ButtonToInteract = "Pickup";
    }

}
