using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCase : MonoBehaviour, IClicked
{
    [SerializeField]
    public Camera cam;
    public int zoomIn;
    private bool unlock = false;
    private bool firstZoom = true;

    public void onClickAction()
    {
        Line TextData = GameObject.Find("gameManager").GetComponent<Line>();
        Dialogue TextBox = GameObject.Find("DialogueParent").GetComponent<Dialogue>();
        string name = gameObject.name;

        if (name == "BookCase_Clickable") {

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            // locks camera
            cam.GetComponent<Camera>().orthographicSize = 3f;
            cam.transform.position = new Vector3(-13f, 0.6f, -10.0f);
            cam.GetComponent<cameraMovement>().enabled = false;

            if (firstZoom)
            {
                firstZoom = false;
                TextBox.PrintLine(TextData.getLine(37));
            }
            else
                TextBox.PrintLine(TextData.getLine(38));
        }

        if (name == "Box")
        {

            if (!unlock)
            {
                TextBox.PrintLine(TextData.getLine(13));

                // checks for key item in hand
                string nameCheck = GameObject.Find("Cursor").GetComponent<Hand>().GetName();
                //Debug.Log("Whats in my hand?: " + nameCheck);
                if (nameCheck == "Key_Hand")
                    unlock = true;

                if (unlock)
                {
                    TextBox.PrintLine(TextData.getLine(8));
                    // disables lock screen
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;

                    GameObject BookCaseKeyItem = GameObject.Find("BusinessCard_Field");
                    BookCaseKeyItem.GetComponent<SpriteRenderer>().enabled = true;
                    TextBox.PrintLine(TextData.getLine(14));

                    Inventory.instance.Remove(Inventory.instance.items.Find(i => i.name == "Key_Hand"));

                    TextBox.PrintLine(TextData.getLine(40));
                }
                else
                    TextBox.PrintLine(TextData.getLine(39));
            }
        }
    }
}
