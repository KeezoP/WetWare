using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public virtual void Use()
    {

        Debug.Log("Inv item to hand: " + name);
        //Debug.Log("Icon " + icon);
        // close UI
        /*GameObject.Find("Cursor").GetComponent<Hand>().setName(name);*/

        // empty hand
        string nameCheck = GameObject.Find("Cursor").GetComponent<Hand>().GetName();
        if (nameCheck != name && nameCheck != null)
            GameObject.Find(nameCheck).GetComponent<FollowMouse>().hideObject();

        // add to hand
        GameObject.Find("Cursor").GetComponent<Hand>().SetName(name);
        GameObject.Find(name).GetComponent<FollowMouse>().isFollowing=true;

    }
}
