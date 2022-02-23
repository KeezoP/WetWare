using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    
    [SerializeField]
    public Camera cam;
    public float cameraSpeed;
    public float zoomSpeed, minZoom, maxZoom;

    private Vector3 cameraPos;
    private Vector3 velocity = new Vector3(0,0,0);

    
    // Update is called once per frame
    void Update()
    {
       
        float horizontalInput = Input.GetAxis("Horizontal");
        cam.transform.position += new Vector3(horizontalInput * cameraSpeed,0,0);
        
        float teleport = cam.transform.position.x;

        if (teleport < -45.0f)
        {
            cam.transform.position += new Vector3(160, 0, 0);
        }

        else if (teleport > 125.0f)
        {
            cam.transform.position -= new Vector3(160, 0, 0);
        }



        if (Input.GetKey(KeyCode.Q))
        {
            zoomIn();    
        }

        if (Input.GetKey(KeyCode.E))
        {
            zoomOut();
        }

    }

    public void zoomIn()
    {
        float newSize = cam.orthographicSize - zoomSpeed;
        cam.orthographicSize = Mathf.Clamp(newSize, minZoom, maxZoom);
    }

    public void zoomOut()
    {
        float newSize = cam.orthographicSize + zoomSpeed;
        cam.orthographicSize = Mathf.Clamp(newSize, minZoom, maxZoom);
    }

}
