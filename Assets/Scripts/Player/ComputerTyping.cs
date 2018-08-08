using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerTyping : MonoBehaviour {
    public GameObject playerobject;


    // Use this for initialization
    void OnEnable () {
        playerobject.GetComponent<PlayerController>().enabled = false;
        playerobject.GetComponent<CameraController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            playerobject.GetComponent<PlayerController>().enabled = true;
            playerobject.GetComponent<CameraController>().enabled = true;
            
            this.gameObject.SetActive(false);
            //gameObject.transform.position = 
        }
    }
}
