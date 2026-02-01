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
    public ItemData currentItem;
    public RawImage currentItemImg;
    public Texture defaultTexture;

    private void Awake()
    {
        instance = this;
        defaultTexture = currentItemImg.texture;
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

    public bool HasThrowable()
    {
        return currentItem != null &&
               currentItem.type == ItemData.ItemType.THROWABLE;
    }

    void AddItem(ItemEvents.ItemEventArgs itemEvent) {

        if (itemEvent.item.type == ItemData.ItemType.PICKUBLE || itemEvent.item.type == ItemData.ItemType.THROWABLE)
        {
            inventary.Add(itemEvent.item);
            currentItem = itemEvent.item;
            currentItemImg.texture = itemEvent.item.icon.texture;
            Debug.Log(itemEvent.item.name);
        }
    }

    public void UseItem(string itemId) {
        foreach (var item in inventary)
        {
            if (item.itemId == itemId && !item.used) {
                item.used = true;
                currentItemImg.texture = defaultTexture;
            }
        }
    }
}
