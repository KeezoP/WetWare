using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IClicked
{

    public void onClickAction()
    {


        Line TextData = GameObject.Find("gameManager").GetComponent<Line>();
        Dialogue TextBox = GameObject.Find("DialogueParent").GetComponent<Dialogue>();
        string name = gameObject.name;

        if (name == "door blue")
        {

            string nameCheck = GameObject.Find("Cursor").GetComponent<Hand>().GetName();
            if (nameCheck == "Icebreaker_Hand") {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                Inventory.instance.Remove(Inventory.instance.items.Find(i => i.name == "Icebreaker_Hand"));
            }
                

            //TextBox.PrintLine(TextData.getLine(12));
        }  
    }
}
