using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public enum ItemType { 
        PICKUBLE,
        THROWABLE,
        MOVABLE
    }

    public ItemType type;
    public string itemId;
    public string itemName;
    public string description;
    public Sprite icon;
    public float weight = 0;

}
