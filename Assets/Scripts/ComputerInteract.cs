using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteract : MonoBehaviour {

    public Canvas UICanvas;
    public Canvas computerCanvas;

    private bool isUsing;
    private GameObject player;
    private Camera computerCam;
    private Animator anim;

    private void Start()
    {
        isUsing = false;
        player = GameObject.FindGameObjectWithTag("Player");
        computerCam = GetComponentInChildren<Camera>();
        anim = computerCam.GetComponent<Animator>();
    }

    private void Update()
    {
        if (isUsing)
        {
            player.SetActive(false);
            computerCam.enabled = true;
            anim.SetBool("isActive", true);
            UICanvas.enabled = false;
            computerCanvas.renderMode = RenderMode.WorldSpace;
            computerCanvas.transform.position = new Vector3(1.188f, 0.976f, -4.963f);
            computerCanvas.transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);
            computerCanvas.transform.localScale = new Vector3(0.0005f, 0.0005f, 0.0005f);

            if (Input.GetButtonDown("Cancel"))
                isUsing = false;
        }
        else
        {
            player.SetActive(true);
            anim.SetBool("isActive", false);
            computerCam.enabled = false;
            UICanvas.enabled = true;
            computerCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        }
    }

	private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("Interact"))
        {
            isUsing = true;
        }
    }
}
