using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peephole : MonoBehaviour, IClicked
{
    private bool firstClick = true;
    private bool firstClickEnemy = true;
    private bool isEnemy = false;
    public void onClickAction()
    {

        Camera cam = Camera.main;
        Line TextData = GameObject.Find("gameManager").GetComponent<Line>();
        Dialogue TextBox = GameObject.Find("DialogueParent").GetComponent<Dialogue>();
        string name = gameObject.name;

        GameObject PeepView = GameObject.Find("Peephole_View");
        GameObject PeepView2 = GameObject.Find("Peephole_View_Background");
        GameObject PeepView3 = GameObject.Find("Peephole_Enemy");
        
        cam.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
        cam.GetComponent<cameraMovement>().enabled = false;
        PeepView.GetComponent<BoxCollider2D>().enabled = true;
        PeepView.GetComponent<SpriteRenderer>().enabled = true;

        PeepView2.GetComponent<BoxCollider2D>().enabled = true;
        PeepView2.GetComponent<SpriteRenderer>().enabled = true;

        if (PeepView3.GetComponent<BigEnemy>().atPeephole)
        {
            isEnemy = true;
            PeepView3.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
            isEnemy = false;                

        // dialogue
        
        // is enemy at peephols
        if(isEnemy)
        {
            if (firstClickEnemy)
            {
                firstClickEnemy = false;
                TextBox.PrintLine(TextData.getLine(20));
            }
            else
                TextBox.PrintLine(TextData.getLine(21));
        }
        else
        {
            if (firstClick)
            {
                firstClick = false;
                TextBox.PrintLine(TextData.getLine(18));
            }
            else
                TextBox.PrintLine(TextData.getLine(19));
        }
    }
}
