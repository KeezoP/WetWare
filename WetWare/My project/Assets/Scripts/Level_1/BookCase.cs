using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCase : MonoBehaviour, IClicked
{
    [SerializeField]
    public Camera cam;
    public int zoomIn;
    private bool unlock = false;

    public void onClickAction()
    {
        Line TextData = GameObject.Find("gameManager").GetComponent<Line>();
        Dialogue TextBox = GameObject.Find("DialogueParent").GetComponent<Dialogue>();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        GameObject BookCaseKeyItem = GameObject.Find("Test Item (2)");
        if(BookCaseKeyItem != null)
            BookCaseKeyItem.GetComponent<SpriteRenderer>().enabled = true;
        // locks camera
        cam.GetComponent<Camera>().orthographicSize = 3f;
        cam.transform.position = new Vector3(-13f, 0.6f, -10.0f);
        cam.GetComponent<cameraMovement>().enabled = false;
        
        TextBox.PrintLine(TextData.getLine(1));
    }
}
