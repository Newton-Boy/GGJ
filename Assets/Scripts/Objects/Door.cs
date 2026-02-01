using UnityEngine;
using static ItemEvents;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class Door : MonoBehaviour, IInteractable
{
    public bool isOpen;
    public bool isUsed;
    public bool isLock;
    public bool hasDialog;
    public string dialog;
    public GameObject key;
    public string dialogName = "door123";
    public string requiredKeyId = "puerta123";

    public ActionData actionData;

    void Awake() {
    }

    public void Interact()
    {
        // Si la puerta está cerrada con llave
        if (isLock && !isOpen)
        {
            // ¿Tengo la llave?
            if (ItemManager.instance.HasItem(requiredKeyId))
            {
                OpenDoor();
            }
            else
            {
                ShowLockedDialog();
            }
            return;
        }

        // Si no está bloqueada
        OpenDoor();
    }

    void ShowLockedDialog() {

        if (!DialogManager.instance.dialogEnd)
        {
            DialogManager.instance.NextLine();
        }
        else
        {
            Debug.Log("pasa");

            TextAsset dialog = Resources.Load<TextAsset>("Dialogs/" + dialogName);
            Debug.Log(dialog);
            if (dialog == null) return;
            DialogManager.instance.ShowDialog(dialog);

        }


    }

    void OpenDoor()
    {
        isOpen = true;
        isLock = false;

        Debug.Log("Puerta abierta");
        ActionEvent.onActionExecuted?.Invoke(new ActionEvent.ActionEventArgs(actionData, "opendoor"));
        // animación
        // sonido
    }

    public bool CanInteract()
    {
        
        return false;
    }


    public void ShowInteraction() {
        GameObject action = transform.GetChild(0).gameObject;
        action.SetActive(!action.activeSelf);
    }

}
