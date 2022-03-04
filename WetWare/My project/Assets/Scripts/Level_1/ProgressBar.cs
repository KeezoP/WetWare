using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public bool doPause = false;
    public bool doBegin = false;
    float progTimer = 0.0f;
    public int progScriptCounter;
    private void Start()
    {
        doPause = false;
        doBegin = false;
        progTimer = 0.0f;
        progScriptCounter = 0;
    }


    void Update()
    {
        // if progress bar is increasing
        if(doBegin && !doPause)
        {
            GameObject.Find("Progress_Bar_Front").GetComponent<SpriteRenderer>().color = new Vector4(0.61f, 0.906f, 0.687f, 1.0f);
            // increase timer
            progTimer += Time.deltaTime;

            // trigger puzzle 1
            if (progTimer > 10.0f && progScriptCounter == 0)
            {
                doPause = true;
                GameObject.Find("Puzzle_1_Hider").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("Puzzle_1_Hider").GetComponent<BoxCollider2D>().enabled = false;
            }
                
            // increase bar progression

            // get current bar stats
            Vector3 oldScale = GameObject.Find("Progress_Bar_Front").GetComponent<Transform>().localScale;
            Vector3 oldPos = GameObject.Find("Progress_Bar_Front").GetComponent<Transform>().position;
            
            // update bar stats
            oldScale.x += Time.deltaTime/100;
            oldPos.x += Time.deltaTime/100;
            
            // if bar is '100%' end bar increase
            if(oldScale.x > 1.1f)
            {
                oldScale.x = 1.1f;
                doBegin = false;
            }

            // update bar
            GameObject.Find("Progress_Bar_Front").GetComponent<Transform>().localScale = oldScale;
            GameObject.Find("Progress_Bar_Front").GetComponent<Transform>().position = oldPos;
        }

        else if(doPause)
        {
            GameObject.Find("Progress_Bar_Front").GetComponent<SpriteRenderer>().color = new Vector4(0.84f, 0.404f, 0.407f, 1.0f);
        }
    }
}
