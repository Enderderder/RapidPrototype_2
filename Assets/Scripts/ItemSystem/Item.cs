﻿using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string ItemName;
    public int itemID;
}