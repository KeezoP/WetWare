using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour, IClicked
{
    [SerializeField]
    public Camera cam;
    public int zoomIn;
    private bool unlock = false;

    public void onClickAction()
    {

        // locks camera
        cam.GetComponent<Camera>().orthographicSize = 1.4f;
        //cam.GetComponent<Camera>().orthographicSize = 3f;
        cam.transform.position = new Vector3(-19.6f, 0.6f, -10.0f);
        cam.GetComponent<cameraMovement>().enabled = false;
        //gameObject.GetComponent<BoxCollider2D>().enabled = false;
        if (!unlock)
        {
            // checks for key item in hand
            string nameCheck = GameObject.Find("Cursor").GetComponent<Hand>().GetName();
            if (nameCheck == "Green Square")
                unlock = true;

            if(unlock)
            {
                // disables lock screen
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                

                // begins download
                GameObject.Find("Progress_Bar_Front").GetComponent<ProgressBar>().doBegin = true;

            }
        }

    }

    public bool isUnlocked()
    {
        if (unlock)
            return true;
        else
            return false;

    }
}
