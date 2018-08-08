using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLogic : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        GameObject.Find("Camera").GetComponent<PlayerGrabbing>().isGrabbing = false;
        //isGrabbing = false;
        //this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.gameObject.transform.SetParent(null);
    }
}
