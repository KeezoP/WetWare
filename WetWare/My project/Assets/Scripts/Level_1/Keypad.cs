using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour, IClicked
{
    public void onClickAction()
    {

        Camera cam = Camera.main;
        Line TextData = GameObject.Find("gameManager").GetComponent<Line>();
        Dialogue TextBox = GameObject.Find("DialogueParent").GetComponent<Dialogue>();
        string name = gameObject.name;

        GameObject KeypadView = GameObject.Find("Keypad_View");

        cam.transform.position = new Vector3(19.2f, 0.0f, -10.0f);
        cam.GetComponent<cameraMovement>().enabled = false;
        KeypadView.GetComponent<BoxCollider2D>().enabled = true;
        KeypadView.GetComponent<SpriteRenderer>().enabled = true;
    }
}
