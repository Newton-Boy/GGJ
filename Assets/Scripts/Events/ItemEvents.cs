using System;
using UnityEngine;

public static class ItemEvents
{
    public static Action<ItemEventArgs> OnItemPick;
    public static Action<ItemEventArgs> OnItemDrop;

    public class ItemEventArgs {

        public ItemData item;
        public string action;

        public ItemEventArgs(ItemData item, string action)
        {
            this.item = item;
            this.action = action;
        }
    }
}


