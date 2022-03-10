using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    public Texture2D cursor;
    public Texture2D cursorClicked;


    private CursorControls controls;

    private Camera mainCamera;
    private GameObject up;
    private GameObject down;
    private GameObject left;
    private GameObject right;

    private void Awake()
    {
        controls = new CursorControls();
        changeCursor(cursor);
        //Cursor.lockState = CursorLockMode.Confined;
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Start is called before the first frame update
    private void Start()
    {
        controls.Mouse.Click.started += _ => startedClick();
        controls.Mouse.Click.performed += _ => endedClick();
    }

    private void startedClick()
    {
        changeCursor(cursorClicked);
        DetectObject();
    }

    private void endedClick()
    {
        changeCursor(cursor);
        
    }

    private void DetectObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.position.ReadValue<Vector2>());

        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        if (hit.collider != null)
        {
            IClicked click = hit.collider.GetComponent<IClicked>();
            Debug.Log("Tag: " + hit.collider.tag + " ID: " + hit.collider.name);
            if (click != null) 
            { 
                click.onClickAction(); 
            }

           
        }
    }





    private void changeCursor(Texture2D cursorType)
    {
        /*
            for finding the 'click point', will use top left of cursor by default
            but here is code for centering click point to middle of cursor icon
            in the event that we make a new cursor icon that intends on clicking
            in the center of the image

            Vector 2 hotspot = new Vector2(cursorType.width/2, cursorType.height/2);
         */

        Cursor.SetCursor(cursorType,Vector2.zero,CursorMode.Auto);
    }


    

}
