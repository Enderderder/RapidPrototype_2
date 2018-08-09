using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteract : MonoBehaviour {

    public Canvas UICanvas;
    public Canvas computerCanvas;
    public GameObject computerScreen;

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
            computerCanvas.transform.position = new Vector3(4.225f, 0.976f, -0.91f);
            computerCanvas.transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);
            computerCanvas.transform.localScale = new Vector3(0.0005f, 0.0005f, 0.0005f);
            computerScreen.SetActive(true);

            if (Input.GetButtonDown("Cancel"))
            {
                isUsing = false;
            }
        }
        else
        {
            player.SetActive(true);
            anim.SetBool("isActive", false);
            computerCam.enabled = false;
            UICanvas.enabled = true;
            computerCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            computerScreen.SetActive(false);
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
