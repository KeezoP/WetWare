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
    private KeyboardControls keyboardControls;

    private void Awake()
    {
        keyboardControls = new KeyboardControls();
    }

    private void OnEnable()
    {
        keyboardControls.Enable();
    }

    private void OnDisable()
    {
        keyboardControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
       
        float moveInput = keyboardControls.Keyboard.Movement.ReadValue<float>();
        Vector3 currentPosition = cam.transform.position;
        currentPosition.x += moveInput * cameraSpeed * Time.deltaTime;
        cam.transform.position = currentPosition;








        // Looping background effect
        float teleport = cam.transform.position.x;
        if (teleport < -38.4f)
        {
            cam.transform.position += new Vector3(76.8f, 0, 0);
        }
        else if (teleport > 38.4f)
        {
            cam.transform.position -= new Vector3(76.8f, 0, 0);
        }



       /* if (Input.GetKey(KeyCode.Q))
        {
            zoomIn();    
        }

        if (Input.GetKey(KeyCode.E))
        {
            zoomOut();
        }*/

    }
/*
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
*/
}
