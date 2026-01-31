using UnityEngine;

public interface IInteractable
{
    void ShowInteraction();
    void Interact();

    bool CanInteract();
}
