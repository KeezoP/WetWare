using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IClicked
{
    [SerializeField] public Camera cam;
    public void onClickAction()
    {
        // if zoomed in, zoom out
        if (cam.GetComponent<Camera>().orthographicSize != 5.3f) {
            cam.GetComponent<Camera>().orthographicSize = 5.3f;
            cam.GetComponent<cameraMovement>().enabled = true;
            cam.transform.position = new Vector3(cam.transform.position.x, 0.0f, -10.0f);

        }

        GameObject monitor = GameObject.Find("Monitor_Clickable");

        if (monitor != null || monitor.GetComponent<Monitor>().isUnlocked() )
        {
            monitor.GetComponent<BoxCollider2D>().enabled = true; 
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

        GameObject Pot = GameObject.Find("BookCase_Clickable");
        
        if (Pot != null)
        {
            Pot.GetComponent<BoxCollider2D>().enabled = true;
            /*if (BookCaseKeyItem != null)
            {
                BookCaseKeyItem.GetComponent<SpriteRenderer>().enabled = false;
            }*/
            /*else
            {
                Pot.SetActive(false);
            }*/

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
        if(PeepView != null)
        {
            PeepView.GetComponent<SpriteRenderer>().enabled = false;
            PeepView.GetComponent<BoxCollider2D>().enabled = false;

            cam.GetComponent<cameraMovement>().enabled = true;
        }

        GameObject WindowView = GameObject.Find("Window_View");
        if (WindowView != null)
        {
            WindowView.GetComponent<SpriteRenderer>().enabled = false;
            WindowView.GetComponent<BoxCollider2D>().enabled = false;

            cam.GetComponent<cameraMovement>().enabled = true;
        }


        GameObject DrawerView = GameObject.Find("Keypad_View");
        if (DrawerView != null)
        {
            DrawerView.GetComponent<SpriteRenderer>().enabled = false;
            DrawerView.GetComponent<BoxCollider2D>().enabled = false;

            cam.GetComponent<cameraMovement>().enabled = true;
        }

    }
}
