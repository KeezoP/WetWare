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
        GameObject BookCaseKeyItem = GameObject.Find("Test Item (2)");

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

        GameObject poster = GameObject.Find("Poster_Clickable");
        GameObject poster2 = GameObject.Find("Poster_Clickable_Dupe");
        GameObject posterKeyItem = GameObject.Find("Test Item (1)");

        if (poster != null)
        {
            poster.GetComponent<BoxCollider2D>().enabled = true;
            if (posterKeyItem != null)
            {

                posterKeyItem.GetComponent<SpriteRenderer>().enabled = false;
            } else
            {
                poster.SetActive(false);
                poster2.SetActive(false);
            }
        }

        GameObject Pot = GameObject.Find("BookCase_Clickable");
        //GameObject BookCaseKeyItem = GameObject.Find("Test Item (2)");

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
    }
}
