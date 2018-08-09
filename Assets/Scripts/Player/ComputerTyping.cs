using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerTyping : MonoBehaviour {
    public GameObject playerobject;

    void OnEnable()
    {
        playerobject.GetComponent<PlayerController>().enabled = false;
        playerobject.GetComponent<CameraController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
