using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{

    [SerializeField]
    ItemData itemData;

    public bool CanInteract()
    {
        throw new System.NotImplementedException();
    }

    public void Interact()
    {
        ItemEvents.OnItemPick?.Invoke(itemData);
        gameObject.SetActive(false);
        //Debug.Log("pasa?");
        //switch (Type) {
        //    case ItemType.KEY:
        //        Debug.Log("Item" + itemName + "Tomado");    
        //    break;
        //    case ItemType.PICKUPABLE:
        //        Debug.Log("Pickupuble" + itemName + "en las manos");
        //    break;
        //    case ItemType.THROGLABLE:
        //        Debug.Log("Thorogable" + itemName + "lanzado");
        //    break;
        //}
    }

    public void ShowInteraction()
    {
        GameObject action = transform.GetChild(0).gameObject;
        action.SetActive(!action.activeSelf);
    }

    void HandleItem() { 
        // tomar objeto y guardarlo en el inventario
        // el ItemManager se encargara de ver si puede ser tomado o no
    }

    void HandlePickuble() { 
        // toma el objeto y lo mueve con el player ademas que lo afecta el peso del objeto en la velocidad
    }

    void HandleThrowable() { 
    
       // toma el objeto, lo mueve con el pero no lo puede soltar hasta lanzarlo
    }





}
