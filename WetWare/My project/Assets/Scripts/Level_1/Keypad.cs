using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour, IClicked
{
    private bool isComplete = false;
    private bool firstZoom = true;
    public void onClickAction()
    {
        if (!isComplete) {
            Camera cam = Camera.main;
            cam.transform.position = new Vector3(19.2f, 0.0f, -10.0f);
            cam.GetComponent<cameraMovement>().enabled = false;

            Line TextData = GameObject.Find("gameManager").GetComponent<Line>();
            Dialogue TextBox = GameObject.Find("DialogueParent").GetComponent<Dialogue>();
            string name = gameObject.name;

            GameObject KeypadView = GameObject.Find("Keypad_View");
            KeypadView.GetComponent<BoxCollider2D>().enabled = true;
            KeypadView.GetComponent<SpriteRenderer>().enabled = true;

            GameObject.Find("KeyPad_Back").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("keypad_1").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("keypad_2").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("keypad_3").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("keypad_4").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("keypad_5").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("keypad_6").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("keypad_7").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("keypad_8").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("keypad_9").GetComponent<BoxCollider2D>().enabled = true;

            if(firstZoom)
            {
                firstZoom = false;
                TextBox.PrintLine(TextData.getLine(30));
            }
            else
                TextBox.PrintLine(TextData.getLine(31));

        }
    }

    public void complete()
    {
        isComplete = true;
    }
}
