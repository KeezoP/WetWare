using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : MonoBehaviour
{
    
    public bool atWindow = false;
    private float scaleMod = 0.001f;
    public float timer = 0.0f;
    public bool begin = false;
    public float timerTarget;

    private void Awake()
    {
        timerTarget = calcScriptTimeTarget();
    }

    // Update is called once per frame
    void Update()
    {
        // if enemy appearance scripts 'begin'
        if (begin)
        {
            if (!atWindow)
            {
                timer += Time.deltaTime;

                // if enough time has passed
                if (timer >= timerTarget)
                {

                    timer = 0.0f;
                    timerTarget = Random.Range(3, 6);
                    atWindow = true;

                }
            }

            else
            {
                GameObject enemy1 = GameObject.Find("Window_Enemy");
                GameObject enemy2 = GameObject.Find("Window_Enemy_Dupe");

                // while at window, blinds have to be closed for n seconds before enemy disappears
                if(GameObject.Find("Blinds_Up").GetComponent<Blinds>().closed)
                {
                    enemy1.GetComponent<SpriteRenderer>().enabled = false;
                    enemy2.GetComponent<SpriteRenderer>().enabled = false;
                    timer += Time.deltaTime;
                } else
                {
                    enemy1.GetComponent<SpriteRenderer>().enabled = true;
                    enemy2.GetComponent<SpriteRenderer>().enabled = true;

                    timer = 0.0f;
                }
                    

                // if enough time has passed
                if (timer >= timerTarget)
                {

                    timer = 0.0f;
                    timerTarget = calcScriptTimeTarget();
                    atWindow = false;

                    enemy1.GetComponent<SpriteRenderer>().enabled = false;
                    enemy2.GetComponent<SpriteRenderer>().enabled = false;
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;


                }
            }
        }
        GameObject WindowView = GameObject.Find("Window_View");

        // position/scale modification while at big window, turned off rn
        if (atWindow && WindowView.GetComponent<SpriteRenderer>().isVisible && 1 == 2)
        {
            Vector3 scale = gameObject.transform.localScale;

            scale.x += scaleMod / 10;
            scale.y += scaleMod / 10;

            // if scaling reaches either limit, flip scale direction
            if (scale.x >= 1.05f || scale.x <= 1.0f)
            {
                scaleMod *= -1.0f;
            }

            gameObject.transform.localScale = scale;
        }
    }

    public void beginMovement()
    {
        begin = true;
    }

    private float calcScriptTimeTarget()
    {
        float random_number = Random.Range(35, 50);
        Debug.Log("Fade: " + random_number + " seconds till appear");

        return random_number;

    }
}
