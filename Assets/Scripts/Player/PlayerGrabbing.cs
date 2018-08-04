using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabbing : MonoBehaviour {

    public float grabDistance;
    public float throwForce;

    private bool isGrabbing = false;
    private RaycastHit hit;
    private Ray grabRay;

    private void Update()
    {
        grabRay = new Ray(transform.position, transform.forward);

        Debug.DrawRay(transform.position, transform.forward * grabDistance);

        if (Input.GetButtonDown("Fire1"))
        {
            if (!isGrabbing)
            {
                if (Physics.Raycast(grabRay, out hit, grabDistance))
                {
                    if (hit.collider.tag == "Pickupable")
                    {
                        isGrabbing = true;
                        hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        hit.collider.gameObject.transform.SetParent(transform);
                        hit.collider.enabled = false;
                    }
                }
            }
            else
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
