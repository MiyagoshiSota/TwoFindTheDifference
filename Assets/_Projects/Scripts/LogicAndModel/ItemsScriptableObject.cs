using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsWrapperView", menuName = "Scriptable Objects/ItemsWrapperView")]
public class ItemsScriptableObject : ScriptableObject
{
    public List<ItemData> itemsList = new List<ItemData>();
}

[Serializable]
public class ItemData
{
    public string itemName;
    public Sprite itemSprite;
    public Vector2 itemPosition;
}