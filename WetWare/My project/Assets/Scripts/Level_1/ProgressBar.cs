using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public bool doPause;
    public bool doBegin;
    private float percentageTimer;
    public int percentage;
    private int progScriptCounter;
    private Line TextData;
    private Dialogue TextBox;
    private void Start()
    {
        TextData = GameObject.Find("gameManager").GetComponent<Line>();
        TextBox = GameObject.Find("DialogueParent").GetComponent<Dialogue>();
        doPause = false;
        doBegin = false;
        percentageTimer = 0.0f;
        percentage = 0;
        progScriptCounter = 0;
    }


    void Update()
    {
        // if progress bar is increasing
        if (doBegin && !doPause)
        {
            GameObject.Find("Progress_Bar_Front").GetComponent<SpriteRenderer>().color = new Vector4(0.61f, 0.906f, 0.687f, 1.0f);

            // increase timer
            percentageTimer += Time.deltaTime;
            // update bar stats
            if (percentageTimer >= 1.0f)
            {
                percentageTimer = 0.0f;
                percentage += 1;

                // get current bar stats
                Vector3 oldScale = GameObject.Find("Progress_Bar_Front").GetComponent<Transform>().localScale;
                Vector3 oldPos = GameObject.Find("Progress_Bar_Front").GetComponent<Transform>().position;

                oldScale.x += 0.0032f;
                oldPos.x += 0.0032f;

                // update bar
                GameObject.Find("Progress_Bar_Front").GetComponent<Transform>().localScale = oldScale;
                GameObject.Find("Progress_Bar_Front").GetComponent<Transform>().position = oldPos;
            }


            // trigger puzzle 1
            if (percentage == 33 && progScriptCounter == 0)
            {
                doPause = true;
                GameObject.Find("Monitor_Backdrop").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("Monitor_Backdrop").GetComponent<BoxCollider2D>().enabled = false;

                // dialogue
                
                bool isAtPC = GameObject.Find("Monitor_Clickable").GetComponent<Monitor>().getAtPC();

                if (isAtPC)
                {
                    TextBox.PrintLine(TextData.getLine(56));
                    GameObject.Find("Monitor_Clickable").GetComponent<Monitor>().setLineTarget(56);
                }
                else
                {
                    TextBox.PrintLine(TextData.getLine(54));
                    GameObject.Find("Monitor_Clickable").GetComponent<Monitor>().setLineTarget(55);
                }
            }

            // increase bar progression



            // if bar is '100%' end bar increase
            if (percentage > 99)
            {
                doBegin = false;
                percentageTimer = 0.0f;
                winCon();
            }


        }

        else if (doPause)
        {
            GameObject.Find("Progress_Bar_Front").GetComponent<SpriteRenderer>().color = new Vector4(0.84f, 0.404f, 0.407f, 1.0f);
        }

        if (percentage == 100)
        {
            percentageTimer += Time.deltaTime;
            if (percentageTimer >= 4.0f)
                Application.Quit();
        }
    }

    public void puzzleComplete()
    {
        // unique dialogue pre puzzle completion
        switch (progScriptCounter)
        {
            case 0: TextBox.PrintLine(TextData.getLine(57)); break;
        }



        progScriptCounter += 1;
        doPause = false;
    }

    private void winCon()
    {
        // lead to next scene, doesn't exist

        // stop big enemy progression, camera movement etc
        GameObject enemy = GameObject.Find("Peephole_Enemy");
        enemy.GetComponent<BigEnemy>().pause();

        // fade to white
        GameObject bs = GameObject.Find("Black_Screen");
        Color newColor = Color.white;
        bs.GetComponent<Image>().color = newColor;
        bs.GetComponent<Image>().CrossFadeAlpha(1.0f, 2.0f, false);

    }

}
