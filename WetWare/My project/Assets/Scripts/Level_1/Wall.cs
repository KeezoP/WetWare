using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IClicked
{
    [SerializeField] public Camera cam;
    public void onClickAction()
    {
        cam.GetComponent<Camera>().orthographicSize = 8.2f;
        cam.GetComponent<cameraMovement>().enabled = true;
        GameObject monitor = GameObject.Find("Monitor_Clickable");

        if(monitor != null && !monitor.GetComponent<SpriteRenderer>().enabled)
        {
            monitor.GetComponent<SpriteRenderer>().enabled = true;
            monitor.GetComponent<BoxCollider2D>().enabled = true;
            Vector3 camPos = cam.transform.position;
            camPos.y = -0.8f;
            cam.transform.position = camPos;
        }               
    }
}
