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
            cam.transform.position = new Vector3(-19.6f, 0.0f, -10.0f);

        }

        GameObject monitor = GameObject.Find("Monitor_Clickable");

        if (monitor != null || monitor.GetComponent<Monitor>().isUnlocked() )
        {
            
            monitor.GetComponent<BoxCollider2D>().enabled = true;

            
        }               
    }
}
