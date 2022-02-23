using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour, IClicked
{
   

    public void onClickAction()
    {


        bool toggleVisible = gameObject.GetComponent<SpriteRenderer>().enabled;

        if (toggleVisible) gameObject.GetComponent<SpriteRenderer>().enabled = false;
        else gameObject.GetComponent<SpriteRenderer>().enabled = true;

    }

}
