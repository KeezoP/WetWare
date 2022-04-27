using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour, IClicked
{
    [SerializeField]
    public Camera cam;
    private bool firstZoom = true;
    private bool unlock = false;
    private bool enterSN = false;
    private bool enterBC = false;
    private bool firstEmpty = true;
    private bool atPC = false;
    private int lineTarget = 99;

    public void onClickAction()
    {
        Line TextData = GameObject.Find("gameManager").GetComponent<Line>();
        Dialogue TextBox = GameObject.Find("DialogueParent").GetComponent<Dialogue>();
        atPC = true;

        if (gameObject.name != "file")
        {
            // if not already zoomed in, run this dialogue
            if (cam.GetComponent<Camera>().orthographicSize != 1.0f)
            {

                // locks camera
                cam.GetComponent<Camera>().orthographicSize = 1.0f;
                cam.transform.position = new Vector3(-19.6f, 0.6f, -10.0f);
                cam.GetComponent<cameraMovement>().enabled = false;

                if (firstZoom)
                {
                    firstZoom = false;
                    TextBox.PrintLine(TextData.getLine(42));

                    // trigger enemy
                    GameObject.Find("Peephole_Enemy").GetComponent<BigEnemy>().beginMovement();
                }
                else
                    TextBox.PrintLine(TextData.getLine(43));
            }

            if (!unlock)
            {
                // checks for key item in hand
                string nameCheck = GameObject.Find("Cursor").GetComponent<Hand>().GetName();
                if (nameCheck == "StickyNote_Hand")
                {

                    Inventory.instance.Remove(Inventory.instance.items.Find(i => i.name == "StickyNote_Hand"));
                    enterSN = true;

                    if (enterBC)
                    {
                        TextBox.PrintLine(TextData.getLine(51));
                    }
                    else
                        TextBox.PrintLine(TextData.getLine(50));



                }

                else if (nameCheck == "BusinessCard_Hand")
                {

                    Inventory.instance.Remove(Inventory.instance.items.Find(i => i.name == "BusinessCard_Hand"));
                    enterBC = true;

                    if (enterSN)
                    {
                        TextBox.PrintLine(TextData.getLine(49));
                    }
                    else
                        TextBox.PrintLine(TextData.getLine(48));

                }

                else
                {
                    // clicked on screen with incorrect key item/empty hand

                    if (enterSN)
                        TextBox.PrintLine(TextData.getLine(47));
                    else if (enterBC)
                        TextBox.PrintLine(TextData.getLine(46));
                    else
                    {
                        if (firstEmpty)
                        {
                            firstEmpty = false;
                            TextBox.PrintLine(TextData.getLine(44));
                        }
                        else
                            TextBox.PrintLine(TextData.getLine(45));
                    }
                }


                if (enterBC && enterSN)
                {
                    unlock = true;
                    TextBox.PrintLine(TextData.getLine(52));
                }

            }

            if (unlock)
            {

                // disables lock screen
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;

                if (lineTarget != 99)
                    TextBox.PrintLine(TextData.getLine(lineTarget));


            }
        }
        else
        {
            // begins download
            GameObject.Find("Progress_Bar_Front").GetComponent<ProgressBar>().doBegin = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            TextBox.PrintLine(TextData.getLine(53));
        }


    }

    public bool isUnlocked()
    {
        if (unlock)
            return true;
        else
            return false;

    }
    public void setAtPC(bool input)
    {
        atPC = input;
    }

    public bool getAtPC ()
    {
        return atPC;
    }

    public void setLineTarget(int input)
    {
        lineTarget = input;
    }
}
