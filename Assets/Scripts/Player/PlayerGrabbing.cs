using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ItemPickUpEvent : UnityEvent<GameObject>
{}
public class DropZoneEvenet : UnityEvent<GameObject>
{}

public class PlayerGrabbing : MonoBehaviour
{
    // Creates a unity event that can notify when player has pickupped something
    public static ItemPickUpEvent OnPlayerPickUp = new ItemPickUpEvent();
    public static DropZoneEvenet OnPlayerDropZone = new DropZoneEvenet();

    public float grabDistance;
    public float throwForce;
    public Camera cam;

    public bool isGrabbing = false;
    private RaycastHit hit;
    private Ray grabRay;

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

    private void Update()
    {
        grabRay = new Ray(transform.position, transform.forward);
        
        Debug.DrawRay(transform.position, transform.forward * grabDistance, Color.black);

        if (!isGrabbing)
        {
            if (Physics.Raycast(grabRay, out hit, grabDistance))
            {
                if (hit.collider.tag == "Pickupable")
                {
                    lastItem = hit.collider.gameObject;

                    lastItem.GetComponent<Renderer>().material.shader = Shader.Find("Custom/Outline");
                
                    if (Input.GetButtonDown("Pickup"))
                    {
                        // Trigger the event
                        OnPlayerPickUp.Invoke(hit.collider.gameObject);

                        isGrabbing = true;
                        hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        
                        hit.collider.gameObject.transform.SetParent(hand);
                        hit.collider.gameObject.transform.position = hand.position;

                        hit.collider.gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
                    }
                }
            }
            else
            {
                if (lastItem != null)
                    lastItem.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
            }
        }
        else
        {
            if (Physics.Raycast(grabRay, out hit, grabDistance) && hit.collider.tag == "DropZone")
            {
                lastDropPoint = hit.collider.gameObject;

                hit.collider.GetComponent<ItemDropPoint>().InRange = true;

                if (Input.GetButtonDown("Pickup"))
                {

                    OnPlayerDropZone.Invoke(hit.collider.gameObject);

                    isGrabbing = false;
                    hand.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;

                    hand.GetChild(0).transform.position = hit.collider.gameObject.transform.position;
                    hand.GetChild(0).SetParent(null);
                    hit.collider.GetComponent<ItemDropPoint>().InRange = false;
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
