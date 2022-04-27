using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    string[] Dialogue;
    private void Awake()
    {
        Dialogue = System.IO.File.ReadAllLines("Assets/Scripts/Level_1/Level_1_Textv2.txt");
    }

    public string getLine(int lineNum)
    {
        return Dialogue[lineNum];
    }
}
