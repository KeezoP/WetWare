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
            case "Green Square":
                //TextBox.fadeIn();
                TextBox.PrintLine(TextData.getLine(4));
                break;

            case "Yellow Square":
                //TextBox.fadeIn();
                TextBox.PrintLine(TextData.getLine(5));
                break;

            case "Red Square":
                //TextBox.fadeIn();
                TextBox.PrintLine(TextData.getLine(0));
                break;

        }



        //Debug.Log("I picked up :" + Item.name);
        Inventory.instance.Add(Item);
        Destroy(gameObject);
    
    }
}
