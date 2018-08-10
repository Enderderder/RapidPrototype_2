using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ItemPickUpEvent : UnityEvent<GameObject>
{}
public class DropZoneEvent : UnityEvent<GameObject>
{}

public class PlayerGrabbing : MonoBehaviour
{
    // Creates a unity event that can notify when player has pickupped something
    public static ItemPickUpEvent OnPlayerPickUp = new ItemPickUpEvent();
    public static DropZoneEvent OnPlayerDropZone = new DropZoneEvent();

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

                Interactable interactScript = targetObject.GetComponent<Interactable>();
                if (interactScript != null)
                {
                    interactScript.OutlineOn();
                    interactScript.ShowInteractHUD(interactUIText);

                    lastItem = targetObject;

                    if(Input.GetKeyDown("e"))
                    {
                        interactScript.OutlineOff();
                        interactScript.HideInteractHUD(interactUIText);
                    }

                    if (targetObject.GetComponent<Pickupable>())
                    {
                        if (Input.GetButtonDown("Pickup"))
                        {
                            // Trigger the event
                            OnPlayerPickUp.Invoke(lastItem);

                            isGrabbing = true;
                            hitInfo.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                            hitInfo.collider.gameObject.transform.SetParent(hand);
                            hitInfo.collider.gameObject.transform.position = hand.position;
                        }
                    }
                }
            }
            else
            {
                if (lastItem != null)
                {
                    lastItem.GetComponent<Interactable>().OutlineOff();
                    lastItem.GetComponent<Interactable>().HideInteractHUD(interactUIText);
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
                lastDropPoint = hitInfo.collider.gameObject;

                hitInfo.collider.GetComponent<ItemDropPoint>().InRange = true;

                if (Input.GetButtonDown("Pickup"))
                {
                    OnPlayerDropZone.Invoke(hitInfo.collider.gameObject);

                    isGrabbing = false;
                    hand.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;

                    hand.GetChild(0).transform.position = hitInfo.collider.gameObject.transform.position;
                    hand.GetChild(0).SetParent(null);
                    hitInfo.collider.GetComponent<ItemDropPoint>().InRange = false;
                }
            }
            else
            {
                if (lastDropPoint != null)
                    lastDropPoint.GetComponent<ItemDropPoint>().InRange = false;

                if (Input.GetButtonDown("Pickup"))
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
