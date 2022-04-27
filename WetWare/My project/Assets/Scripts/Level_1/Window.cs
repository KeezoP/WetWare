using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour, IClicked
{
    public bool firstClick = true;
    public bool firstClickEnemyGround = true;
    public bool firstClickEnemyWindow = true;



    public void onClickAction()
    {

        Camera cam = Camera.main;
        Line TextData = GameObject.Find("gameManager").GetComponent<Line>();
        Dialogue TextBox = GameObject.Find("DialogueParent").GetComponent<Dialogue>();
        string name = gameObject.name;

        GameObject WindowView = GameObject.Find("Window_View");
        GameObject WindowView2 = GameObject.Find("Window_View_Background");
        GameObject EnemyPos1 = GameObject.Find("Enemy_Pos_1");
        GameObject EnemyPos2 = GameObject.Find("Enemy_Pos_2");
        GameObject EnemyPos3 = GameObject.Find("Enemy_Pos_3");
        GameObject EnemyClose = GameObject.Find("Enemy_Close");

        cam.transform.position = new Vector3(-38.1f, 0.0f, -10.0f);
        cam.GetComponent<cameraMovement>().enabled = false;
        
        WindowView.GetComponent<BoxCollider2D>().enabled = true;
        WindowView.GetComponent<SpriteRenderer>().enabled = true;

        WindowView2.GetComponent<BoxCollider2D>().enabled = true;
        WindowView2.GetComponent<SpriteRenderer>().enabled = true;

        /*EnemyPos1.GetComponent<SpriteRenderer>().enabled = true;
        EnemyPos2.GetComponent<SpriteRenderer>().enabled = true;
        EnemyPos3.GetComponent<SpriteRenderer>().enabled = true;*/

        bool isWindow = false;
        if(EnemyClose.GetComponent<SmallEnemy>().atWindow) {

            EnemyClose.GetComponent<SpriteRenderer>().enabled = true;
            isWindow = true;
        }


        // dialogue


        int enemyGroundScreenPos = GameObject.Find("Peephole_Enemy").GetComponent<BigEnemy>().screenPos;
        bool isGround = false;
        GameObject WindowClick = GameObject.Find("Window_Collidor");
        // because of two windows datasets, have to unify bool values
        firstClick = WindowClick.GetComponent<Window>().firstClick;
        firstClickEnemyGround = WindowClick.GetComponent<Window>().firstClickEnemyGround;
        firstClickEnemyWindow = WindowClick.GetComponent<Window>().firstClickEnemyWindow;

        // is street enemy on screen
        if (enemyGroundScreenPos > 0 && enemyGroundScreenPos < 4)
            isGround = true;

        // is any enemy on screen
        if(isWindow || isGround)
        {
            // window enemy has priority
            if(isWindow)
            {
                // first interaction
                if(firstClickEnemyWindow)
                {
                    WindowClick.GetComponent<Window>().firstClickEnemyWindow = false;
                    TextBox.PrintLine(TextData.getLine(16));
                }
                else
                    TextBox.PrintLine(TextData.getLine(17));
            }
            else
            {
                if (firstClickEnemyGround)
                {
                    WindowClick.GetComponent<Window>().firstClickEnemyGround = false;
                    TextBox.PrintLine(TextData.getLine(12));
                }
                else
                {
                    switch (enemyGroundScreenPos)
                    {
                        case 1: TextBox.PrintLine(TextData.getLine(13)); break;
                        case 2: TextBox.PrintLine(TextData.getLine(14)); break;
                        case 3: TextBox.PrintLine(TextData.getLine(15)); break;
                    }
                }
            }
        }
        else
        {
            // first click on window
            if(firstClick)
            {
                WindowClick.GetComponent<Window>().firstClick = false;
                TextBox.PrintLine(TextData.getLine(10));
            } 
            else
                TextBox.PrintLine(TextData.getLine(11));
        }


    }


    
}
