using System;
using UnityEngine;

public static class ActionEvent
{
    public static Action<ActionEventArgs> onActionExecuted;

    public class ActionEventArgs
    {

        public ActionData actionData;
        public string action;

        public ActionEventArgs(ActionData actionData, string action)
        {
            this.actionData = actionData;
            this.action = action;
        }
    }
}
