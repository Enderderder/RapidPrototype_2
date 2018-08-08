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

    public bool isGrabbing = false;
    private RaycastHit hit;
    private Ray grabRay;

    private GameObject lastItem;

    private GameObject[] currItemDestinations;

    private void Update()
    {
        grabRay = new Ray(transform.position, transform.forward);
        
        Debug.DrawRay(transform.position, transform.forward * grabDistance, Color.black);

        if (!isGrabbing)
        {
            

            if (Physics.Raycast(grabRay, out hit, grabDistance))
            {
                if (hit.collider.gameObject.GetComponent<Pickupable>())
                {
                    lastItem = hit.collider.gameObject;

                    lastItem.GetComponent<Renderer>().material.shader = Shader.Find("Custom/ItemOutline");
                
                    if (Input.GetButtonDown("Fire1"))
                    {
                        // Trigger the event
                        OnPlayerPickUp.Invoke(hit.collider.gameObject);

                        isGrabbing = true;
                        hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        hit.collider.gameObject.transform.SetParent(transform);
                        hit.collider.enabled = false;
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
                if (Input.GetButtonDown("Fire1"))
                {
                    isGrabbing = false;
                    transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                    transform.GetChild(0).GetComponent<Collider>().enabled = true;
                    transform.GetChild(0).transform.position = hit.collider.gameObject.transform.position;
                    transform.GetChild(0).SetParent(null);
                }
            }
            else
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    isGrabbing = false;
                    transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                    transform.GetChild(0).GetComponent<Collider>().enabled = true;
                    transform.GetChild(0).GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
                    transform.GetChild(0).SetParent(null);
                }
            }
        }
    }
}
