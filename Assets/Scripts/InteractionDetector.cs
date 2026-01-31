using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    public IInteractable currentInteractable;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && currentInteractable != null) {
            currentInteractable.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            currentInteractable = interactable;
            interactable.ShowInteraction();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable)) {
            currentInteractable = null;
            interactable.ShowInteraction();
        }
    }
}
