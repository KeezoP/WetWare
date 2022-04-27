using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour, IClicked
{
    private string correctPin = "1234";
    public string[] userInput = new string[4];
    private float[] buttonTime = new float[9];
    private int counter = 0;
    string output;
    bool error = false;
    float cooldown = 3.0f;
    public void onClickAction()
    {
        Line TextData = GameObject.Find("gameManager").GetComponent<Line>();
        Dialogue TextBox = GameObject.Find("DialogueParent").GetComponent<Dialogue>();
        Drawer data = GameObject.Find("KeyPad_Info").GetComponent<Drawer>();
        int tempCounter = data.returnInputLength();
        
        if (tempCounter <=3)
        {

            switch(gameObject.name)
            {
                case "keypad_1": output = "1"; break;
                case "keypad_2": output = "2"; break;
                case "keypad_3": output = "3"; break;
                case "keypad_4": output = "4"; break;
                case "keypad_5": output = "5"; break;
                case "keypad_6": output = "6"; break;
                case "keypad_7": output = "7"; break;
                case "keypad_8": output = "8"; break;
                case "keypad_9": output = "9"; break;
            }
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            switch (tempCounter)
            {
                case 0: GameObject.Find("pin_1").GetComponent<SpriteRenderer>().enabled = true; break;
                case 1: GameObject.Find("pin_2").GetComponent<SpriteRenderer>().enabled = true; break;
                case 2: GameObject.Find("pin_3").GetComponent<SpriteRenderer>().enabled = true; break;
                case 3: GameObject.Find("pin_4").GetComponent<SpriteRenderer>().enabled = true; break;
            }

            Debug.Log("Key: " + output + "      Slot: " + tempCounter);
            data.userInput[tempCounter] = output;
            data.setCounter(tempCounter+1);

        }

        // attempt unlock
        if(tempCounter == 3)
        {
            userInput = data.userInput;
            string code = userInput[0] + userInput[1] + userInput[2] + userInput[3];
            string unlockCode = data.returnCorrectCode();

            if(code == unlockCode)
            {
                Debug.Log("Codes match");
                TextBox.PrintLine(TextData.getLine(33));
                // disable keypad
                GameObject.Find("KeyPad_Back").GetComponent<BoxCollider2D>().enabled = false;
                GameObject.Find("keypad_1").GetComponent<BoxCollider2D>().enabled = false;
                GameObject.Find("keypad_2").GetComponent<BoxCollider2D>().enabled = false;
                GameObject.Find("keypad_3").GetComponent<BoxCollider2D>().enabled = false;
                GameObject.Find("keypad_4").GetComponent<BoxCollider2D>().enabled = false;
                GameObject.Find("keypad_5").GetComponent<BoxCollider2D>().enabled = false;
                GameObject.Find("keypad_6").GetComponent<BoxCollider2D>().enabled = false;
                GameObject.Find("keypad_7").GetComponent<BoxCollider2D>().enabled = false;
                GameObject.Find("keypad_8").GetComponent<BoxCollider2D>().enabled = false;
                GameObject.Find("keypad_9").GetComponent<BoxCollider2D>().enabled = false;

                GameObject.Find("pin_1").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("pin_2").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("pin_3").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("pin_4").GetComponent<SpriteRenderer>().enabled = false;

                GameObject keypad = GameObject.Find("Keypad_View");
                keypad.GetComponent<BoxCollider2D>().enabled = false;
                keypad.GetComponent<SpriteRenderer>().enabled = false;

                GameObject keypad_View = GameObject.Find("Keypad_Clickable");
                keypad_View.GetComponent<Keypad>().complete();
                keypad_View.GetComponent<BoxCollider2D>().enabled = false;

                GameObject.Find("Open_Drawer").GetComponent<SpriteRenderer>().enabled = true;
                GameObject note = GameObject.Find("StickyNote_Field");
                note.GetComponent<BoxCollider2D>().enabled = true;
                note.GetComponent<SpriteRenderer>().enabled = true;

            }
            else
            {
                GameObject red = GameObject.Find("KeyPad_Red");
                red.GetComponent<SpriteRenderer>().enabled = true;
                red.GetComponent<BoxCollider2D>().enabled = true;


                data.error = true;
                Debug.Log("Codes don't match");
                TextBox.PrintLine(TextData.getLine(32));
                data.userInput = new string[4];
                data.setCounter(0);
            }


            // if succeed, perma disable view, change view to open drawer view
                // sidenote, when picking up sticky note, perma disable open drawer view
            // if fail, display red view for n seconds, then disable red view
                // also reset counter to 0

        }

        
    }

    public void Update()
    {

        if ( gameObject.name == "keypad_1")
        {
            for (int i = 0; i < 9; i++)
            {
                int temp = i + 1;
                string search = "keypad_" + temp;
                
                if(GameObject.Find(search).GetComponent<SpriteRenderer>().enabled)
                {
                    buttonTime[i] += Time.deltaTime;
                }

                if(buttonTime[i] >= 0.3f)
                {
                    GameObject.Find(search).GetComponent<SpriteRenderer>().enabled = false;
                    buttonTime[i] = 0.0f;
                }
            }
        }

        if(error)
        {
            for (int i = 0; i < 9; i++)
            {
                int temp = i + 1;
                string search = "keypad_" + temp;

                GameObject.Find(search).GetComponent<BoxCollider2D>().enabled = false;
            }
            
            cooldown -= Time.deltaTime;
            if(cooldown <= 0)
            {
                error = false;
                cooldown = 3.0f;
                GameObject red = GameObject.Find("KeyPad_Red");
                red.GetComponent<SpriteRenderer>().enabled = false;
                red.GetComponent<BoxCollider2D>().enabled = false;

                GameObject.Find("pin_1").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("pin_2").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("pin_3").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("pin_4").GetComponent<SpriteRenderer>().enabled = false;

                for (int i = 0; i < 9; i++)
                {
                    int temp = i + 1;
                    string search = "keypad_" + temp;

                    GameObject.Find(search).GetComponent<BoxCollider2D>().enabled = true;
                }
            }
        }


    }

    public int returnInputLength()
    {
        return counter;
    }

    public void setCounter(int inputCounter)
    {
        counter = inputCounter;
    }

    public string returnCorrectCode()
    {
        return correctPin;
    }
}
