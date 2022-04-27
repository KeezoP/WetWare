using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Painting : MonoBehaviour, IClicked
{
    [SerializeField]
    public Camera cam;
    public int zoomIn;
    public bool altered = false;

    public void onClickAction()
    {
        Line TextData = GameObject.Find("gameManager").GetComponent<Line>();
        Dialogue TextBox = GameObject.Find("DialogueParent").GetComponent<Dialogue>();
        TextBox.PrintLine(TextData.getLine(0));

        altered = !altered;



        GameObject painting = GameObject.Find("Painting");
        GameObject painting2 = GameObject.Find("Painting_Dupe");

        painting.GetComponent<Painting>().altered = altered;
        painting2.GetComponent<Painting>().altered = altered;

        Transform p1 = painting.GetComponent<Transform>();
        Transform p2 = painting2.GetComponent<Transform>();

        if (altered)
        {
            Vector3 rotateAngle = new Vector3(0.0f, 0.0f, 10.0f);
            Vector3 position = new Vector3(p1.position.x + 1.0f, p1.position.y + 1.0f, -2.0f);
            Vector3 position2 = new Vector3(p2.position.x + 1.0f, p2.position.y + 1.0f, -2.0f);

            p1.position = position;
            p2.position = position2;

            p1.Rotate(rotateAngle);
            p2.Rotate(rotateAngle);
        }
        else
        {
            Vector3 rotateAngle = new Vector3(0.0f, 0.0f, -10.0f);
            Vector3 position = new Vector3(p1.position.x - 1.0f, p1.position.y - 1.0f, -2.0f);
            Vector3 position2 = new Vector3(p2.position.x - 1.0f, p2.position.y - 1.0f, -2.0f);

            p1.position = position;
            p2.position = position2;

            p1.Rotate(rotateAngle);
            p2.Rotate(rotateAngle);
        }

        //TextBox.PrintLine(TextData.getLine(1));
    }
}
