using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinds : MonoBehaviour, IClicked
{
    public bool firstClickOpen = true;
    public bool firstClickClosed = true;
    public bool firstClickEnemy = true;
    public bool closed = false;

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

            up.GetComponent<Blinds>().closed = true;
            
        } 
        else if (name == "Blinds_Down" || name == "Blinds_Down_Dupe") {

            //up.GetComponent<SpriteRenderer>().enabled = true;
            up.GetComponent<BoxCollider2D>().enabled = true;

            //upDupe.GetComponent<SpriteRenderer>().enabled = true;
            upDupe.GetComponent<BoxCollider2D>().enabled = true;

            down.GetComponent<SpriteRenderer>().enabled = false;
            down.GetComponent<BoxCollider2D>().enabled = false;

            downDupe.GetComponent<SpriteRenderer>().enabled = false;
            downDupe.GetComponent<BoxCollider2D>().enabled = false;

            up.GetComponent<Blinds>().closed = false;
        }

        // is enemy at window
        bool isEnemy = GameObject.Find("Enemy_Close").GetComponent<SpriteRenderer>().enabled;

        // did player just close blinds
        bool justClosedBlinds = up.GetComponent<Blinds>().closed;

        firstClickOpen = up.GetComponent<Blinds>().firstClickOpen;
        firstClickClosed = up.GetComponent<Blinds>().firstClickClosed;
        firstClickEnemy = up.GetComponent<Blinds>().firstClickEnemy;
        

        // did player open or close blinds
        if (justClosedBlinds)
        {
            // is enemy at window
            if(isEnemy)
            {
                // first interaction?
                if (firstClickEnemy) {
                    up.GetComponent<Blinds>().firstClickEnemy = false;

                    TextBox.PrintLine(TextData.getLine(4));
                }

                else
                    TextBox.PrintLine(TextData.getLine(5));
            }
            else
            {
                // first interaction?
                if (firstClickClosed)
                {
                    up.GetComponent<Blinds>().firstClickClosed = false;

                    TextBox.PrintLine(TextData.getLine(2));
                }

                else
                    TextBox.PrintLine(TextData.getLine(3));
            }



           
        }
        else
        {
            // is enemy at window
            if (isEnemy)
            {
                // first interaction?
                if (firstClickEnemy)
                {
                    up.GetComponent<Blinds>().firstClickEnemy = false;

                    TextBox.PrintLine(TextData.getLine(8));
                }

                else
                    TextBox.PrintLine(TextData.getLine(9));
            }
            else
            {
                // first interaction?
                if (firstClickOpen)
                {
                    up.GetComponent<Blinds>().firstClickOpen = false;

                    TextBox.PrintLine(TextData.getLine(6));
                }

                else
                    TextBox.PrintLine(TextData.getLine(7));
            }
        }
        

    }
}
