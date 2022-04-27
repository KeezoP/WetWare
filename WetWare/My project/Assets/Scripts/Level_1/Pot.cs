using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour, IClicked
{
    [SerializeField]
    public Camera cam;
    public int zoomIn;
    private bool firstInteraction = true;
    private bool firstZoom = true;
    public void onClickAction()
    {
        Line TextData = GameObject.Find("gameManager").GetComponent<Line>();
        Dialogue TextBox = GameObject.Find("DialogueParent").GetComponent<Dialogue>();
        string name = gameObject.name;
        if(name == "Pot_Clickable")
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            cam.GetComponent<Camera>().orthographicSize = 2f;
            cam.transform.position = new Vector3(5.5f, -3f, -10.0f);
            cam.GetComponent<cameraMovement>().enabled = false;

            if(firstZoom)
            {
                firstZoom = false;
                TextBox.PrintLine(TextData.getLine(26));
            }
            else
                TextBox.PrintLine(TextData.getLine(27));
        }
        if (name == "Pot_Moveable" && firstInteraction)
        {
            Vector3 potLocation = gameObject.transform.position;
            potLocation.x += 0.8f;
            gameObject.transform.position = potLocation;

            TextBox.PrintLine(TextData.getLine(12));
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            GameObject key = GameObject.Find("Key_Field");
            key.GetComponent<BoxCollider2D>().enabled = true;
            key.GetComponent<SpriteRenderer>().enabled = true;
            TextBox.PrintLine(TextData.getLine(28));
            firstInteraction = false;
        }
    }
}
