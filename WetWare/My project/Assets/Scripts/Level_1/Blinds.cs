using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinds : MonoBehaviour, IClicked
{
    
    private bool closed = false;

    public void onClickAction()
    {
        Line TextData = GameObject.Find("gameManager").GetComponent<Line>();
        Dialogue TextBox = GameObject.Find("DialogueParent").GetComponent<Dialogue>();
        string name = gameObject.name;

        GameObject up = GameObject.Find("Blinds_Up");
        GameObject upDupe = GameObject.Find("Blinds_Up_Dupe");
        GameObject down = GameObject.Find("Blinds_Down");
        GameObject downDupe = GameObject.Find("Blinds_Down_Dupe");

        if (name == "Blinds_Up" || name == "Blinds_Up_Dupe") {

            //up.GetComponent<SpriteRenderer>().enabled = false;
            up.GetComponent<BoxCollider2D>().enabled = false;

            //upDupe.GetComponent<SpriteRenderer>().enabled = false;
            upDupe.GetComponent<BoxCollider2D>().enabled = false;

            down.GetComponent<SpriteRenderer>().enabled = true;
            down.GetComponent<BoxCollider2D>().enabled = true;

            downDupe.GetComponent<SpriteRenderer>().enabled = true;
            downDupe.GetComponent<BoxCollider2D>().enabled = true;

            closed = true;

        } else if (name == "Blinds_Down" || name == "Blinds_Down_Dupe") {

            //up.GetComponent<SpriteRenderer>().enabled = true;
            up.GetComponent<BoxCollider2D>().enabled = true;

            //upDupe.GetComponent<SpriteRenderer>().enabled = true;
            upDupe.GetComponent<BoxCollider2D>().enabled = true;

            down.GetComponent<SpriteRenderer>().enabled = false;
            down.GetComponent<BoxCollider2D>().enabled = false;

            downDupe.GetComponent<SpriteRenderer>().enabled = false;
            downDupe.GetComponent<BoxCollider2D>().enabled = false;

            closed = false;
        }

       
    }
}
