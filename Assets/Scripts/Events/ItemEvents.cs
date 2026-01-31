using System;
using UnityEngine;

public static class ItemEvents
{
    public static Action<ItemData> OnItemPick;
    public static Action<ItemData> OnItemDrop;
}
