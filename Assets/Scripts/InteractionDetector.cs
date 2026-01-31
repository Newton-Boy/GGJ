using UnityEngine;

public class InteractionDetector : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("prueba");
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            Debug.Log("prueba");
            interactable.Interact();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable)) {

            interactable.Interact();
        }
    }
}
