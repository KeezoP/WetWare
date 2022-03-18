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

        GameObject poster1 = GameObject.Find("Poster_Clickable");
        GameObject poster2 = GameObject.Find("Poster_Clickable_Dupe");

        poster1.GetComponent<BoxCollider2D>().enabled = false;

        GameObject PosterKeyItem = GameObject.Find("Test Item (1)");

        if (PosterKeyItem != null)
            PosterKeyItem.GetComponent<SpriteRenderer>().enabled = true;

        // locks camera
        cam.GetComponent<Camera>().orthographicSize = 3f;
        cam.transform.position = new Vector3(-41f, 0.6f, -10.0f);
        cam.GetComponent<cameraMovement>().enabled = false;

        TextBox.PrintLine(TextData.getLine(1));
    }
}
