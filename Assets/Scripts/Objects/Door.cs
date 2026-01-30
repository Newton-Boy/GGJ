using UnityEngine;

public class Door : MonoBehaviour
{
    public bool canAction;
    public bool isUsed;
    public bool isLock;
    public bool hasDialog;
    public string dialog;
    public GameObject key;


    void Update() {

        PerformAction();
    }

    void PerformAction() {

        if (!isUsed && Input.GetKeyDown(KeyCode.Space)) {


        }

    }


    void OnTriggerStay2D(Collider2D collider) {

        canAction = true;

        if (collider.CompareTag("Player")) {
            // permitir accionar 
            // validar si existe en el inventario la llave
        }
        
    }

    void OnTriggerExit2D(Collider2D collider) {

        canAction = false;

    }

}
