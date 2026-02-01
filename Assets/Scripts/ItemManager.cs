using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static ItemManager instance;


    public List<ItemData> inventary = new();
    public int maxItems;
    public GameObject currentObject;
    public bool canTakeItem;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        ItemEvents.OnItemPick += AddItem;
    }

    public bool HasItem(string itemId)
    {
        foreach (var item in inventary)
        {
            if (item.itemId == itemId)
                return true;
        }
        return false;
    }

    void AddItem(ItemEvents.ItemEventArgs itemEvent) {

        if (itemEvent.item.type == ItemData.ItemType.PICKUBLE) {
            inventary.Add(itemEvent.item);
            Debug.Log(itemEvent.item.name);
        }
    }
}
