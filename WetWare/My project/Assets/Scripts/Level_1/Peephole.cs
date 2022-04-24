using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peephole : MonoBehaviour, IClicked
{
    public void onClickAction()
    {

        Camera cam = Camera.main;
        Line TextData = GameObject.Find("gameManager").GetComponent<Line>();
        Dialogue TextBox = GameObject.Find("DialogueParent").GetComponent<Dialogue>();
        string name = gameObject.name;

        GameObject PeepView = GameObject.Find("Peephole_View");

        cam.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
        cam.GetComponent<cameraMovement>().enabled = false;
        PeepView.GetComponent<BoxCollider2D>().enabled = true;
        PeepView.GetComponent<SpriteRenderer>().enabled = true;
    }
}
