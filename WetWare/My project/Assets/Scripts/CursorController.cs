using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    public Texture2D cursor;
    public Texture2D cursorClicked;


    private CursorControls controls;

    private Camera mainCamera;


    private void Awake()
    {
        controls = new CursorControls();
        changeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
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
    }

    private void endedClick()
    {
        changeCursor(cursor);
        DetectObject();
    }

    private void DetectObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.position.ReadValue<Vector2>());
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                IClicked click = hit.collider.GetComponent<IClicked>();
                if (click != null) click.onClickAction();
                Debug.Log("Hit: " + hit.collider.tag);
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
