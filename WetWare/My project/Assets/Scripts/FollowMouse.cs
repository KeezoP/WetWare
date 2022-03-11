using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    public bool isFollowing = false;
    // Update is called once per frame
    void Update()
    {
        if (isFollowing) {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
            Worldpos.z = -9;
            gameObject.transform.position = Worldpos;
        }
    }

    public void hideObject()
    {
        isFollowing = false;
        gameObject.transform.position = new Vector3(0, 0, 2);
    }
}
