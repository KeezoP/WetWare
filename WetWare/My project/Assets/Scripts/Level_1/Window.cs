using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour, IClicked
{
    public void onClickAction()
    {

        Camera cam = Camera.main;
        Line TextData = GameObject.Find("gameManager").GetComponent<Line>();
        Dialogue TextBox = GameObject.Find("DialogueParent").GetComponent<Dialogue>();
        string name = gameObject.name;

        GameObject WindowView = GameObject.Find("Window_View");

        cam.transform.position = new Vector3(-40.2f, 0.0f, -10.0f);
        cam.GetComponent<cameraMovement>().enabled = false;
        WindowView.GetComponent<BoxCollider2D>().enabled = true;
        WindowView.GetComponent<SpriteRenderer>().enabled = true;
    }
}
