using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public List<Item> items;
}

[System.Serializable]
public class Item
{
    public string title;
    public string description;
    public Sprite image;
}
