using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ItemPickUpEvent : UnityEvent<GameObject>
{}


public class PlayerGrabbing : MonoBehaviour
{
    // Creates a unity event that can notify when player has pickupped something
    public static ItemPickUpEvent OnPlayerPickUp = new ItemPickUpEvent();

    public float grabDistance;
    public float throwForce;

    public GameObject interactUIText;

    public bool isGrabbing = false;

    private Camera fpsCamera;
    private GameObject lastItem;
    private GameObject lastDropPoint;

    private GameObject[] currItemDestinations;
    private Transform hand;
    Vector3 curScreenSpace;
    Vector3 curPosition;

    private void Start()
    {
        hand = GameObject.Find("hand").transform;
    }

    private void Awake()
    {
        fpsCamera = GetComponent<Camera>();
    }


    private void Update()
    {
        Ray grabRay = fpsCamera.ViewportPointToRay(Vector3.one / 2.0f);
        Debug.DrawRay(grabRay.origin, grabRay.direction * grabDistance, Color.black);

        if (!isGrabbing)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(grabRay, out hitInfo, grabDistance))
            {
                GameObject targetObject = hitInfo.collider.gameObject;

                var interactScript = targetObject.GetComponent<Pickupable>();
                if (interactScript != null)
                {
                    interactScript.OutlineOn();
                    interactScript.ShowInteractHUD(interactUIText);

                    lastItem = targetObject;

                    if (Input.GetButtonDown("Pickup"))
                    {
                        // Trigger the event
                        OnPlayerPickUp.Invoke(lastItem);

                        isGrabbing = true;
                        hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        
                        hit.collider.gameObject.transform.SetParent(hand);
                        hit.collider.gameObject.transform.position = hand.position;

                        interactScript.OutlineOff();
                        interactScript.HideInteractHUD(interactUIText);
                    }
                }
            }
            else
            {
                if (lastItem != null)
                {
                    lastItem.GetComponent<Pickupable>().OutlineOff();
                    lastItem.GetComponent<Pickupable>().HideInteractHUD(interactUIText);
                }
            }
        }
        else
        {
            //Vector3 pos = cam.WorldToScreenPoint(hit.collider.gameObject.transform.position);
            //Vector3 offset = hit.collider.gameObject.transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, pos.z));
            //curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pos.z);
            //curPosition = cam.ScreenToWorldPoint(curScreenSpace) + offset;
            //hit.collider.gameObject.transform.position = curPosition;

            RaycastHit hitInfo;
            if (Physics.Raycast(grabRay, out hitInfo, grabDistance) && hitInfo.collider.tag == "DropZone")
            {
                lastDropPoint = hit.collider.gameObject;

                hitInfo.collider.GetComponent<ItemDropPoint>().InRange = true;

                if (Input.GetButtonDown("Pickup"))
                {
                    isGrabbing = false;
                    hand.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;

                    hand.GetChild(0).transform.position = hit.collider.gameObject.transform.position;
                    hand.GetChild(0).SetParent(null);
                    hitInfo.collider.GetComponent<ItemDropPoint>().InRange = false;
                }
            }
            else
            {
                if (lastDropPoint != null)
                    lastDropPoint.GetComponent<ItemDropPoint>().InRange = false;

                if (Input.GetButtonDown("Fire1"))
                {
                    isGrabbing = false;
                    hand.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;

                    hand.GetChild(0).GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
                    hand.transform.GetChild(0).SetParent(null);
                }
            }
        }
    }
}
