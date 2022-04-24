using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Poster : MonoBehaviour, IClicked
{
    [SerializeField]
    public Camera cam;
    public int zoomIn;
    private bool unlock = false;

    public void onClickAction()
    {
        Line TextData = GameObject.Find("gameManager").GetComponent<Line>();
        Dialogue TextBox = GameObject.Find("DialogueParent").GetComponent<Dialogue>();

        GameObject poster = GameObject.Find("Poster_Clickable");

        poster.GetComponent<BoxCollider2D>().enabled = false;
        poster.GetComponent<SpriteRenderer>().enabled = false;

        GameObject PosterKeyItem = GameObject.Find("Code_Field");

        if (PosterKeyItem != null)
        {
            PosterKeyItem.GetComponent<SpriteRenderer>().enabled = true;
            PosterKeyItem.GetComponent<BoxCollider2D>().enabled = true;
        }

        // locks camera
        cam.GetComponent<Camera>().orthographicSize = 1.4f;
        cam.transform.position = new Vector3(-16.5f, 2f, -10.0f);
        cam.GetComponent<cameraMovement>().enabled = false;

        //TextBox.PrintLine(TextData.getLine(1));
    }
}
