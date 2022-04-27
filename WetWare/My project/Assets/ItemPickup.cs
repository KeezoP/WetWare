using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour, IClicked
{

    public Item Item;
    private bool firstDetach = true;
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
                TextBox.PrintLine(TextData.getLine(34));
                break;

            case "BusinessCard_Hand":
                TextBox.PrintLine(TextData.getLine(41));
                break;

            case "Key_Hand":
                TextBox.PrintLine(TextData.getLine(29));
                break;

            case "Code_Hand":
                TextBox.PrintLine(TextData.getLine(36));
                break;

            case "Puzzle2Solutions_Hand":
                TextBox.PrintLine(TextData.getLine(1));
                break;
        }
        Debug.Log("Item " + Item + " | name: "+Item.name);
        Inventory.instance.Add(Item);
        
        switch (Item.name)
        {

            case "Icebreaker_Hand":

                GameObject door = GameObject.Find("door blue");
                GameObject ice = GameObject.Find("Icebreaker_Field");

                door.GetComponent<BoxCollider2D>().enabled = true;
                door.GetComponent<SpriteRenderer>().enabled = true;
                door.GetComponent<Door>().detach();

                ice.GetComponent<BoxCollider2D>().enabled = false;
                ice.GetComponent<SpriteRenderer>().enabled = false;

                if(firstDetach)
                {
                    firstDetach = false;
                    TextBox.PrintLine(TextData.getLine(24));
                }
                else
                    TextBox.PrintLine(TextData.getLine(25));


                break;

            case "StickyNote_Hand":
                Camera cam = Camera.main;
                cam.orthographicSize = 5.3f;
                cam.GetComponent<cameraMovement>().enabled = true;
                cam.transform.position = new Vector3(cam.transform.position.x, 0.0f, -10.0f);

                GameObject.Find("Open_Drawer").GetComponent<SpriteRenderer>().enabled = false;
                Destroy(gameObject);
                break;
            default: Destroy(gameObject); break;

        }
    }
}
