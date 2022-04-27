using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_1 : MonoBehaviour, IClicked
{
    [SerializeField] private bool isGreen = false; 
    public Camera cam;

    public void onClickAction()
    {
        // red 
        //Color red = Color()



        /*bool toggleVisible = gameObject.GetComponent<SpriteRenderer>().enabled;

        if (toggleVisible) gameObject.GetComponent<SpriteRenderer>().enabled = false;
        else gameObject.GetComponent<SpriteRenderer>().enabled = true;*/


        if (GameObject.Find("Monitor_Backdrop").GetComponent<SpriteRenderer>().enabled == false) {
            switch (gameObject.name)
            {
                case "1":
                    toggleColour(gameObject);
                    toggleColour(GameObject.Find("2"));
                    toggleColour(GameObject.Find("4"));
                    break;

                case "2":
                    toggleColour(gameObject);
                    toggleColour(GameObject.Find("1"));
                    toggleColour(GameObject.Find("3"));
                    toggleColour(GameObject.Find("5"));
                    break;

                case "3":
                    toggleColour(gameObject);
                    toggleColour(GameObject.Find("2"));
                    toggleColour(GameObject.Find("6"));
                    break;

                case "4":
                    toggleColour(gameObject);
                    toggleColour(GameObject.Find("1"));
                    toggleColour(GameObject.Find("5"));
                    toggleColour(GameObject.Find("7"));
                    break;

                case "5":
                    toggleColour(gameObject);
                    toggleColour(GameObject.Find("2"));
                    toggleColour(GameObject.Find("4"));
                    toggleColour(GameObject.Find("6"));
                    toggleColour(GameObject.Find("8"));
                    break;

                case "6":
                    toggleColour(gameObject);
                    toggleColour(GameObject.Find("3"));
                    toggleColour(GameObject.Find("5"));
                    toggleColour(GameObject.Find("9"));
                    break;

                case "7":
                    toggleColour(gameObject);
                    toggleColour(GameObject.Find("4"));
                    toggleColour(GameObject.Find("8"));
                    break;

                case "8":
                    toggleColour(gameObject);
                    toggleColour(GameObject.Find("5"));
                    toggleColour(GameObject.Find("7"));
                    toggleColour(GameObject.Find("9"));
                    break;

                case "9":
                    toggleColour(gameObject);
                    toggleColour(GameObject.Find("6"));
                    toggleColour(GameObject.Find("8"));
                    break;

                case "Reset":
                    for (int i = 1; i < 10; i++)
                    {
                        GameObject.Find(i.ToString()).GetComponent<SpriteRenderer>().color = new Vector4(0.47f, 0.0f, 0.11f, 1.0f);
                        GameObject.Find(i.ToString()).GetComponent<Puzzle_1>().isGreen = false;
                    }
                    break;

            }


            int puzzle_1_Counter = 0;
            for (int i = 1; i < 10; i++)
            {
                if (GameObject.Find(i.ToString()).GetComponent<Puzzle_1>().isGreen) puzzle_1_Counter++;
            }

            if (puzzle_1_Counter == 9)
            {
                for (int i = 1; i < 10; i++)
                {
                    GameObject.Find(i.ToString()).GetComponent<CircleCollider2D>().enabled = false;
                }
                GameObject.Find("Progress_Bar_Front").GetComponent<ProgressBar>().puzzleComplete();
                GameObject.Find("Monitor_Backdrop").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Monitor_Backdrop").GetComponent<BoxCollider2D>().enabled = true;
            }

        }

    }

    private void toggleColour(GameObject circle)
    {
        Color red = new Vector4(0.47f, 0.0f, 0.11f, 1.0f);
        //rgba(119, 0, 28, 1)
        Color green = new Vector4(0.61f, 0.906f, 0.687f, 1.0f);

        Color current = circle.GetComponent<SpriteRenderer>().color;

        // toggle

        if (current != green)
        {
            circle.GetComponent<SpriteRenderer>().color = green;
            circle.GetComponent<Puzzle_1>().isGreen = true;
        }
        else
        {
            circle.GetComponent<SpriteRenderer>().color = red;
            circle.GetComponent<Puzzle_1>().isGreen = false;
        }
    }
    
}
