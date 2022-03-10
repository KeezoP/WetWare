using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IClicked
{

    public Item Item;
    public void onClickAction()
    {
        pickUp();
    
    }

    void pickUp() {
        Debug.Log("Picking up item " + Item.name);
        Inventory.instance.Add(Item);
        Destroy(gameObject);
    
    }
}
