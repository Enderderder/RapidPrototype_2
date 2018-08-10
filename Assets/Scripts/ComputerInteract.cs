using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerInteract : MonoBehaviour {

    public Canvas UICanvas;
    public Canvas computerCanvas;
    public GameObject computerScreen;
    public Text percentage;

    private bool isUsing;
    private GameObject player;
    private Camera computerCam;
    private Animator anim;
    private Text pressEText;

    private void Start()
    {
        isUsing = false;
        player = GameObject.FindGameObjectWithTag("Player");
        computerCam = GetComponentInChildren<Camera>();
        anim = computerCam.GetComponent<Animator>();
        pressEText = GameObject.Find("PressEInteractText").GetComponent<Text>();
        pressEText.enabled = false;
    }

    private void Update()
    {
        if (percentage.text == "100%")
        {
            isUsing = false;
        }

        if (isUsing)
        {
            pressEText.enabled = false;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pressEText.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pressEText.enabled = false;
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
