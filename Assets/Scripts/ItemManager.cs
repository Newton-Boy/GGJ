using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created



    public List<ItemData> inventary = new();
    public int maxItems;
    public GameObject currentObject;
    public bool canTakeItem;

    private void OnEnable()
    {
        ItemEvents.OnItemPick += AddItem;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddItem(ItemEvents.ItemEventArgs itemEvent) {

        if (itemEvent.item.type == ItemData.ItemType.PICKUBLE) {
            inventary.Add(itemEvent.item);
            Debug.Log(itemEvent.item.name);
        }
    }
}
