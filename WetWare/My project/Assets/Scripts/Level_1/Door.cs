using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IClicked
{
    private bool isAttached = false;
    public float timer = 0.0f;
    private int battery = 99;
    public float decayTarget = 2.0f;
    public void onClickAction()
    {


        Line TextData = GameObject.Find("gameManager").GetComponent<Line>();
        Dialogue TextBox = GameObject.Find("DialogueParent").GetComponent<Dialogue>();
        string name = gameObject.name;

        if (name == "door blue")
        {

            string nameCheck = GameObject.Find("Cursor").GetComponent<Hand>().GetName();
            if (nameCheck == "Icebreaker_Hand" && battery > 0) {

                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;

                GameObject ice = GameObject.Find("Icebreaker_Field");
                ice.GetComponent<BoxCollider2D>().enabled = true;
                ice.GetComponent<SpriteRenderer>().enabled = true;

                Inventory.instance.Remove(Inventory.instance.items.Find(i => i.name == "Icebreaker_Hand"));
                isAttached = true;
            }
                
            // dialogue
            if(nameCheck == "Icebreaker_Hand")
            {
                TextBox.PrintLine(TextData.getLine(23));
            }
            else
                TextBox.PrintLine(TextData.getLine(22));
        }  
    }
    public bool locked()
    {
        if (isAttached && battery > 0)
            return true;
        else 
            return false;
    }
    private void Update()
    {
        // if icebreaker attached to door, drain icebreaker
        if(isAttached && battery > 0)
        {
            timer += Time.deltaTime;
            if(timer >= decayTarget)
            {
                battery -= 1;
                timer = 0.0f;
            }
        }
    }

    public void detach()
    {
        isAttached = false;
    }
}
