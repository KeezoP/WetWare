using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    private bool isPrinting = false;
    private string lineToPrint;
    private int printCounter = 0;
    private float timePerChar = 0.05f;
    private float timer = 0;
    public float fadeVal = 0.1f;
    private bool finishedFading = true;
    private bool first = true;
    private float firstTimer = 0.0f;
    string Output = null;

    public void Awake()
    {
        GameObject.Find("DialogueParent").GetComponent<Image>().canvasRenderer.SetAlpha(0.0f);
    }

    private void Update()
    {
        if (first)
        {
            if (firstTimer < 2.5f)
            {
                firstTimer += Time.deltaTime;
            }
            else
            {
                first = false;
                Line TextData = GameObject.Find("gameManager").GetComponent<Line>();
                Dialogue TextBox = GameObject.Find("DialogueParent").GetComponent<Dialogue>();
                TextBox.PrintLine(TextData.getLine(58));
            }
        }
        // if printing begins
        if(isPrinting)
        {
            timer += Time.deltaTime;

            // if enough time has passed
            if (timer >= timePerChar && finishedFading) {

                fadeVal = 0.25f;

                // prints 
                if (printCounter <= lineToPrint.Length)
                {
                    //letter by letter
                    /*string Output = lineToPrint.Substring(0, printCounter);
                    GameObject box = GameObject.Find("TextBox");
                    box.GetComponent<Text>().text = Output;
                    printCounter++;
                    timer = 0.0f;*/

                    // search for line breaker "|"
                   /* int findNextLine = lineToPrint.IndexOf("|", printCounter);
                    Debug.Log("Was a | found? : " + findNextLine);

                    // if no line segments
                    if (findNextLine == -1)
                        Output = lineToPrint.Substring(0, lineToPrint.Length);
                    else
                        Output = lineToPrint.Substring(printCounter, findNextLine);
*/
                    //Debug.Log("Line to print: " + Output);

                    Output = lineToPrint.Substring(0, lineToPrint.Length);

                    //word by word
                    int findNextWord = Output.IndexOf(" ", printCounter);
                    if (findNextWord == -1)
                        findNextWord = Output.Length;


                    Output = Output.Substring(0, findNextWord);
                    //Debug.Log("Word to print: " + Output);
                    GameObject box = GameObject.Find("TextBox");
                    box.GetComponent<Text>().text = Output;
                    printCounter = findNextWord+1;
                    timer = 0.0f;

                    // |



                }
                else 
                {
                    fadeVal = 3f;
                    // wait x seconds then fade
                    if (timer >= fadeVal)
                    {
                        isPrinting = false;
                        fadeOut();
                    }
                    fadeVal = 0.1f;
                }
            } else if(timer >= fadeVal) {
                timer = 0.0f;
                finishedFading = true;
            }
            
            
        }
    }

    public void PrintLine(string line)
    {

        GameObject.Find("TextBox").GetComponent<Text>().text = "";
        lineToPrint = line;
        printCounter = 0;
        timer = 0.0f;
        isPrinting = true;
        fadeIn();
    }

    public void fadeIn()
    {
        /*finishedFading = false;
        gameObject.GetComponent<Image>().CrossFadeAlpha(1.0f, fadeVal, false);
        GameObject.Find("TextBox").GetComponent<Text>().CrossFadeAlpha(1.0f, fadeVal, false);*/
        gameObject.GetComponent<Image>().canvasRenderer.SetAlpha(1.0f);
        GameObject.Find("TextBox").GetComponent<Text>().canvasRenderer.SetAlpha(1.0f);
        finishedFading = false;
    }

    public void fadeOut()
    {
        finishedFading = false;
        gameObject.GetComponent<Image>().CrossFadeAlpha(0.0f, fadeVal, false);
        GameObject.Find("TextBox").GetComponent<Text>().CrossFadeAlpha(0.0f, fadeVal, false);
    }



}
