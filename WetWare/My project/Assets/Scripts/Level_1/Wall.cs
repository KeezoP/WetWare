using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IClicked
{
    [SerializeField] public Camera cam;
    public void onClickAction()
    {
        // if zoomed in, zoom out
        if (cam.orthographicSize != 5.3f) {
            cam.orthographicSize = 5.3f;
            cam.GetComponent<cameraMovement>().enabled = true;
            cam.transform.position = new Vector3(cam.transform.position.x, 0.0f, -10.0f);

        }

        GameObject monitor = GameObject.Find("Monitor_Clickable");

        if (monitor != null || monitor.GetComponent<Monitor>().isUnlocked() )
        {
            monitor.GetComponent<BoxCollider2D>().enabled = true;
            monitor.GetComponent<Monitor>().setAtPC(false);
        }

        GameObject BookCase = GameObject.Find("BookCase_Clickable");
        GameObject BookCaseKeyItem = GameObject.Find("BusinessCard_Field");

        if (BookCase != null)
        {
            BookCase.GetComponent<BoxCollider2D>().enabled = true;
            if (BookCaseKeyItem != null)
            {
                BookCaseKeyItem.GetComponent<SpriteRenderer>().enabled = false;
            } else
            {
                BookCase.SetActive(false);
            }
            
        } 

        GameObject painting = GameObject.Find("Painting_Clickable");
        GameObject painting2 = GameObject.Find("Painting_Clickable_Dupe");
        GameObject paintingKeyItem = GameObject.Find("Test Item (1)");

        if (painting != null)
        {
            painting.GetComponent<BoxCollider2D>().enabled = true;
            if (paintingKeyItem != null)
            {

                paintingKeyItem.GetComponent<SpriteRenderer>().enabled = false;
            } else
            {
                painting.SetActive(false);
                painting2.SetActive(false);
            }
        }

        GameObject Pot = GameObject.Find("Pot_Clickable");
        
        if (Pot != null)
        {
            Pot.GetComponent<BoxCollider2D>().enabled = true;
            

        }

        GameObject Poster = GameObject.Find("Poster_Clickable");
        GameObject PosterKeyItem = GameObject.Find("Code_Field");

        if (Poster != null)
        {
            Poster.GetComponent<BoxCollider2D>().enabled = true;
            if (PosterKeyItem != null)
            {
                PosterKeyItem.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                Poster.SetActive(false);
            }

        }

        GameObject PeepView = GameObject.Find("Peephole_View");
        GameObject PeepView2 = GameObject.Find("Peephole_View_Background");
        GameObject PeepView3 = GameObject.Find("Peephole_Enemy");

        if(PeepView != null)
        {
            PeepView.GetComponent<SpriteRenderer>().enabled = false;
            PeepView.GetComponent<BoxCollider2D>().enabled = false;

            PeepView2.GetComponent<SpriteRenderer>().enabled = false;
            PeepView2.GetComponent<BoxCollider2D>().enabled = false;

            PeepView3.GetComponent<SpriteRenderer>().enabled = false;

            cam.GetComponent<cameraMovement>().enabled = true;
        }

        GameObject WindowView = GameObject.Find("Window_View");
        GameObject WindowView2 = GameObject.Find("Window_View_Background");

        GameObject EnemyPos1 = GameObject.Find("Enemy_Pos_1");
        GameObject EnemyPos2 = GameObject.Find("Enemy_Pos_2");
        GameObject EnemyPos3 = GameObject.Find("Enemy_Pos_3");
        GameObject EnemyClose = GameObject.Find("Enemy_Close");

        if (WindowView != null)
        {
            WindowView.GetComponent<SpriteRenderer>().enabled = false;
            WindowView.GetComponent<BoxCollider2D>().enabled = false;
            WindowView2.GetComponent<SpriteRenderer>().enabled = false;
            WindowView2.GetComponent<BoxCollider2D>().enabled = false;

            EnemyClose.GetComponent<SpriteRenderer>().enabled = false;


            cam.GetComponent<cameraMovement>().enabled = true;
        }


        GameObject KeypadView = GameObject.Find("Keypad_View");
        if (KeypadView != null)
        {
            KeypadView.GetComponent<SpriteRenderer>().enabled = false;
            KeypadView.GetComponent<BoxCollider2D>().enabled = false;

            cam.GetComponent<cameraMovement>().enabled = true;

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
        }

    }
}
