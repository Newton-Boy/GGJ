using UnityEngine;

[CreateAssetMenu(fileName = "ActionData", menuName = "Scriptable Objects/ActionData")]
public class ActionData : ScriptableObject
{
    public enum ActionType { 
        Actionable,
        Waitable
    }

    public ActionType type;

    public string actionName;
    public string description;
    public Vector2 newLocation;

}
