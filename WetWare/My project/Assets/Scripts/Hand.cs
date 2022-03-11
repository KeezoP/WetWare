using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{

    private string itemName;

    private void Awake()
    {
        itemName = null;
    }


    public void SetName(string input)
    {
        itemName = input;
    }
    public string GetName()
    {
        return itemName;
    }

}
