using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropPoint : MonoBehaviour {

    [Header("Sprites")]
    public Sprite inactiveSprite;
    public Sprite activeSprite;

    public bool InRange { get; set; }
    private PlayerGrabbing playerGrabScript;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        InRange = false;
        playerGrabScript = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<PlayerGrabbing>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (playerGrabScript.isGrabbing)
        {
            spriteRenderer.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
        }

        if (InRange)
        {
            spriteRenderer.sprite = activeSprite;
        }
        else
        {
            spriteRenderer.sprite = inactiveSprite;
        }
    }
}
