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
    public Camera cam;

    public bool isGrabbing = false;
    private RaycastHit hit;
    private Ray grabRay;

    private GameObject lastItem;

    private GameObject[] currItemDestinations;
    Vector3 curScreenSpace;
    Vector3 curPosition;

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

                    lastItem.GetComponent<Renderer>().material.shader = Shader.Find("Custom/Outline");
                
                    if (Input.GetButtonDown("Fire1"))
                    {
                        // Trigger the event
                        OnPlayerPickUp.Invoke(hit.collider.gameObject);

                        isGrabbing = true;
                        //hit.collider.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        //hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
                        hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        //hit.collider.gameObject.GetComponent<Rigidbody>().detectCollisions = true;
                        
                        //hit.collider.gameObject.GetComponent<Rigidbody>().velocity = (pos - hit.collider.gameObject.transform.position) * 10;
                        hit.collider.gameObject.transform.SetParent(GameObject.Find("hand").transform);
                        hit.collider.gameObject.transform.position = GameObject.Find("hand").transform.position;

                        //hit.collider.enabled = false;
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
            //Vector3 pos = cam.WorldToScreenPoint(hit.collider.gameObject.transform.position);
            //Vector3 offset = hit.collider.gameObject.transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, pos.z));
            //curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pos.z);
            //curPosition = cam.ScreenToWorldPoint(curScreenSpace) + offset;
            //hit.collider.gameObject.transform.position = curPosition;

            if (Physics.Raycast(grabRay, out hit, grabDistance) && hit.collider.tag == "DropZone")
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    isGrabbing = false;
                    //hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
                    GameObject.Find("hand").transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                    
                    GameObject.Find("hand").transform.GetChild(0).transform.position = hit.collider.gameObject.transform.position;
                    GameObject.Find("hand").transform.GetChild(0).SetParent(null);
                }
            }
            else
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    isGrabbing = false;
                    GameObject.Find("hand").transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                   
                    GameObject.Find("hand").transform.GetChild(0).GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
                    GameObject.Find("hand").transform.GetChild(0).SetParent(null);
                }
            }
        }
    }


   }
