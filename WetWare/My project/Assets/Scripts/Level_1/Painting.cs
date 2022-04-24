using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Painting : MonoBehaviour, IClicked
{
    [SerializeField]
    public Camera cam;
    public int zoomIn;
    private bool unlock = false;

    public void onClickAction()
    {
        Line TextData = GameObject.Find("gameManager").GetComponent<Line>();
        Dialogue TextBox = GameObject.Find("DialogueParent").GetComponent<Dialogue>();

        GameObject painting = GameObject.Find("Painting");
        GameObject painting2 = GameObject.Find("Painting_Dupe");

        painting.GetComponent<BoxCollider2D>().enabled = false;
        painting2.GetComponent<BoxCollider2D>().enabled = false;

        Transform p1 = painting.GetComponent<Transform>();
        Transform p2 = painting2.GetComponent<Transform>();

        Vector3 rotateAngle = new Vector3(0.0f, 0.0f, 10.0f);
        Vector3 position = new Vector3(p1.position.x + 1.0f, p1.position.y + 1.0f, -2.0f);
        Vector3 position2 = new Vector3(p2.position.x + 1.0f, p2.position.y + 1.0f, -2.0f);

        p1.position = position;
        p2.position = position2;

        p1.Rotate(rotateAngle);
        p2.Rotate(rotateAngle);

        /*
        GameObject key = GameObject.Find("Key_Field");
        key.GetComponent<BoxCollider2D>().enabled = true;
        key.GetComponent<SpriteRenderer>().enabled = true;
        */
        //TextBox.PrintLine(TextData.getLine(1));
    }
}
