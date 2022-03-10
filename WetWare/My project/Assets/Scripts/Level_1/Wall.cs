using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IClicked
{
    [SerializeField] public Camera cam;
    public void onClickAction()
    {
        //cam.GetComponent<Camera>().orthographicSize = 8.3f;
        //cam.GetComponent<Camera>().orthographicSize = 12.5f;
        cam.GetComponent<Camera>().orthographicSize = 5.3f;

        cam.GetComponent<cameraMovement>().enabled = true;
        GameObject monitor = GameObject.Find("Monitor_Clickable");

        if(monitor != null && !monitor.GetComponent<SpriteRenderer>().enabled)
        {
            monitor.GetComponent<SpriteRenderer>().enabled = true;
            monitor.GetComponent<BoxCollider2D>().enabled = true;
            /*Vector3 camPos = cam.transform.position;
            camPos.y = -0.8f;*/
            cam.transform.position = new Vector3(-19.6f, 0.0f, -10.0f);
            //cam.transform.position = camPos;
        }               
    }
}
