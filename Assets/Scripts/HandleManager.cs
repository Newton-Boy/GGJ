using UnityEngine;

public class HandleManager : MonoBehaviour
{

    public bool isBusy;
    public bool showGui;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {

            showGui = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {

            showGui = false;
        }
    }
}
