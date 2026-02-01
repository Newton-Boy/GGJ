using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static ItemManager instance;


    public List<ItemData> inventary = new();
    public int maxItems;
    public bool canTakeItem;
    public RawImage currentItem;
    public Texture defaultTexture;

    private void Awake()
    {
        instance = this;
        defaultTexture = currentItem.texture;
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

        if (itemEvent.item.type == ItemData.ItemType.PICKUBLE || itemEvent.item.type == ItemData.ItemType.THROWABLE)
        {
            inventary.Add(itemEvent.item);
            currentItem.texture = itemEvent.item.icon.texture;
            Debug.Log(itemEvent.item.name);
        }
    }

    public void UseItem(string itemId) {
        foreach (var item in inventary)
        {
            if (item.itemId == itemId && !item.used) {
                item.used = true;
                currentItem.texture = defaultTexture;
            }
        }
    }
}
