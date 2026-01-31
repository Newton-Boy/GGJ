using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public bool canAction;
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
        GetDialog();
        GameObject action = transform.GetChild(0).gameObject;
        action.SetActive(!action.activeSelf);
    }

    public bool CanInteract()
    {
        Debug.Log("Otras");
        return false;
    }


    void GetDialog() {
        
        TextAsset dialog = Resources.Load<TextAsset>("Dialogs/" + dialogName);
        Debug.Log(dialog);
        if (dialog == null) return;
        DialogManager.instance.ShowDialog(dialog);

    }
}
