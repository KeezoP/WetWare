using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigEnemy : MonoBehaviour
{
    public int screenPos = 0;
    public bool atPeephole = false;
    private float scaleMod = 0.002f;
    private float timer = 0.0f;
    private bool begin = false;
    private float timerTarget;
    private int endScript = 0;
    GameObject PeepView;
    GameObject bs;

    // Start is called before the first frame update
    private void Awake()
    {
        //timerTarget = calcScriptTimeTarget();
        timerTarget = 2;
        PeepView = GameObject.Find("Peephole_View");
        bs = GameObject.Find("Black_Screen");
        bs.GetComponent<Image>().CrossFadeAlpha(0.0f, 1.0f, false);

    }

    // Update is called once per frame
    void Update()
    {
        // if enemy movement scripts 'begin' and isn't at final stage ( 5 )
        if (begin && screenPos < 5)
        {
            timer += Time.deltaTime;

            // if enough time has passed
            if(timer >= timerTarget)
            {
                screenPos += 1;
                timer = 0.0f;
                timerTarget = calcScriptTimeTarget();

                if (screenPos == 4)
                    atPeephole = true;
                else
                    atPeephole = false;
            }
        }

        

        // makes the big enemy faintly scale in/out while at peephole
        if (atPeephole && PeepView.GetComponent<SpriteRenderer>().isVisible)
        {
            Vector3 scale = gameObject.transform.localScale;

            scale.x += scaleMod/100;
            scale.y += scaleMod/100;

            // if scaling reaches either limit, flip scale direction
            if (scale.x >= 1.05f || scale.x <= 1.0f) {
                scaleMod *= -1.0f;
            }

            gameObject.transform.localScale = scale;
        }

        

        // player lose attempt
        if (screenPos == 5)
        {
            // if player safe
            if (GameObject.Find("door blue").GetComponent<Door>().locked()) {
                ResetPosition();

                GameObject windowEnemy = GameObject.Find("Enemy_Close");
                if (!windowEnemy.GetComponent<SmallEnemy>().begin)
                    windowEnemy.GetComponent<SmallEnemy>().begin = true;
            } 
            
            // player death script
            else
            {
             

                Camera cam = Camera.main;

                // lock camera
                cam.GetComponent<cameraMovement>().enabled = false;
                GameObject pos4 = GameObject.Find("Peephole_Enemy");
                Vector3 scale = pos4.transform.localScale;


                timer += Time.deltaTime;

                // fade to black
                if (endScript == 0)
                {
                    bs.GetComponent<Image>().CrossFadeAlpha(1.0f, 0.5f, false);
                    endScript = 1;
                }

                
                else if (timer >=2.0f && endScript == 1)
                {
                    // set camera pos to door
                    cam.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
                    cam.GetComponent<Camera>().orthographicSize = 5.3f;
                    GameObject PeepView = GameObject.Find("Peephole_View");
                    GameObject PeepView2 = GameObject.Find("Peephole_View_Background");

                    PeepView.GetComponent<SpriteRenderer>().enabled = false;
                    PeepView.GetComponent<BoxCollider2D>().enabled = false;

                    PeepView2.GetComponent<SpriteRenderer>().enabled = false;
                    PeepView2.GetComponent<BoxCollider2D>().enabled = false;

                    endScript = 2;

                    // lights fade back in
                    bs.GetComponent<Image>().CrossFadeAlpha(0.8f, 0.5f, false);
                    timer = 0.0f;
                    scale.x = 0.5f;
                    scale.y = 0.5f;
                    pos4.transform.localScale = scale;
                    
                    
                    pos4.GetComponent<SpriteRenderer>().enabled = true;
                }

                else if (timer >= 1.5f && endScript == 2)
                {
                    bs.GetComponent<Image>().canvasRenderer.SetAlpha(0.0f);
                    endScript = 3;
                }

                else if (endScript == 3)
                {
                    scale.x += 0.02f;
                    scale.y += 0.02f;
                    Vector3 enemyPos = pos4.transform.position;
                    enemyPos.y -= 0.02f;
                    pos4.transform.position = enemyPos;

                    if (scale.x >= 2.4)
                    {
                        scale.x = 2.4f;
                        scale.y = scale.x;
                        endScript = 4;

                        bs.GetComponent<Image>().CrossFadeAlpha(1.0f, 2.0f, false);
                    }
                    pos4.transform.localScale = scale;
                }

            }
        } else
        {
            renderEnemy();
        }


        
    }

    public void ResetPosition()
    {
        screenPos = 0;
        timer = 0.0f;
        timerTarget = calcScriptTimeTarget();
    }

    public void beginMovement() {
        begin = true;
    }

    private float calcScriptTimeTarget()
    {
        float random_number = Random.Range(8, 12);
        Debug.Log("Murk: " + random_number + "s to move, position: "+screenPos);
        return random_number;

    }

    private void renderEnemy()
    {
      GameObject pos1 = GameObject.Find("Enemy_Pos_1");    
      GameObject pos2 = GameObject.Find("Enemy_Pos_2");    
      GameObject pos3 = GameObject.Find("Enemy_Pos_3");    
      GameObject pos4 = GameObject.Find("Peephole_Enemy");

        pos1.GetComponent<SpriteRenderer>().enabled = false;
        pos2.GetComponent<SpriteRenderer>().enabled = false;
        pos3.GetComponent<SpriteRenderer>().enabled = false;
        pos4.GetComponent<SpriteRenderer>().enabled = false;
        
        switch(screenPos)
        {
            case 1:
                if (GameObject.Find("Window_View").GetComponent<SpriteRenderer>().enabled) {
                    pos1.GetComponent<SpriteRenderer>().enabled = true;
                }
                break;
            case 2:
                if (GameObject.Find("Window_View").GetComponent<SpriteRenderer>().enabled)
                {
                    pos2.GetComponent<SpriteRenderer>().enabled = true;
                }
                break;
            case 3:
                if (GameObject.Find("Window_View").GetComponent<SpriteRenderer>().enabled)
                {
                    pos3.GetComponent<SpriteRenderer>().enabled = true;
                }
                break;
            case 4:
                if (PeepView.GetComponent<SpriteRenderer>().isVisible)
                {
                    pos4.GetComponent<SpriteRenderer>().enabled = true;
                }
                break;
        }
        
    }
}
