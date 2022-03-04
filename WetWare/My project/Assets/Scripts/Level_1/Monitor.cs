using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour, IClicked
{
    [SerializeField]
    public Camera cam;
    public int zoomIn;

    public void onClickAction()
    {

        bool toggleVisible = gameObject.GetComponent<SpriteRenderer>().enabled;

        if (toggleVisible)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
           
            cam.GetComponent<Camera>().orthographicSize = 1.4f;
            cam.transform.position = new Vector3(-19.6f,0.6f,-10.0f);
            cam.GetComponent<cameraMovement>().enabled = false;
            GameObject.Find("Progress_Bar_Front").GetComponent<ProgressBar>().doBegin = true;
        }

    }
}
