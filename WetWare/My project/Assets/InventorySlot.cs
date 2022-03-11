using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;
    [SerializeField] Button open; 
    [SerializeField] Button close; 
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void useItem()
    {
        if(item != null)
        {

            
            item.Use();
            open.gameObject.SetActive(true);
            close.gameObject.SetActive(false);
            GameObject.Find("ItemParent").SetActive(false);
        }
    }
}
    