using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropPoint : MonoBehaviour {

    [Header("Sprites")]
    public Sprite inactiveSprite;
    public Sprite activeSprite;

    public bool InRange { get; set; }
    private PlayerGrabbing playerGrabScript;

    private void Awake()
    {
        InRange = false;
        playerGrabScript = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<PlayerGrabbing>();
    }

    private void Update()
    {
        if (InRange)
        {
            GetComponent<SpriteRenderer>().sprite = activeSprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = inactiveSprite;
        }

        if (playerGrabScript.isGrabbing)
        {
            GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
