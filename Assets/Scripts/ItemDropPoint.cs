using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropPoint : MonoBehaviour {

    [Header("Sprites")]
    public Sprite inactiveSprite;
    public Sprite activeSprite;

    [System.NonSerialized] public bool inRange;

    private void Awake()
    {
        inRange = false;
    }

    private void Update()
    {
        if (inRange)
        {
            GetComponent<SpriteRenderer>().sprite = activeSprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = inactiveSprite;
        }
    }
}
