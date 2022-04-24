using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour, IClicked
{

    public Item Item;
    public void onClickAction()
    {
        pickUp();
    
    }

    void pickUp() {
        Line TextData = GameObject.Find("gameManager").GetComponent<Line>();
        Dialogue TextBox = GameObject.Find("DialogueParent").GetComponent<Dialogue>();
        
        switch (Item.name)
        {
            case "StickyNote_Hand":
                TextBox.PrintLine(TextData.getLine(4));
                break;

            case "BusinessCard_Hand":
                TextBox.PrintLine(TextData.getLine(15));
                break;

            case "Key_Hand":
                TextBox.PrintLine(TextData.getLine(3));
                break;

            case "Code_Hand":
                TextBox.PrintLine(TextData.getLine(0));
                break;

        }
        Debug.Log("Item " + Item + " | name: "+Item.name);
        Inventory.instance.Add(Item);
        if(Item.name != "Icebreaker_Hand")
            Destroy(gameObject);
        else
        {
            GameObject door = GameObject.Find("door blue");
            door.GetComponent<BoxCollider2D>().enabled = true;
            door.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
