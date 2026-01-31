using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public bool isOpen;
    public bool isUsed;
    public bool isLock;
    public bool hasDialog;
    public string dialog;
    public GameObject key;
    public string dialogName = "door123";

    void Awake() {

    }

    public void Interact()
    {
        if (!DialogManager.instance.dialogEnd)
        {
            DialogManager.instance.NextLine();
        }
        else {
            Debug.Log("pasa");

            TextAsset dialog = Resources.Load<TextAsset>("Dialogs/" + dialogName);
            Debug.Log(dialog);
            if (dialog == null) return;
            DialogManager.instance.ShowDialog(dialog);

        }

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
