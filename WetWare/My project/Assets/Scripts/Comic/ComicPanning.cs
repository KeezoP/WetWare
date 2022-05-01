using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComicPanning : MonoBehaviour
{

    private float timer = 0.0f;
    public int positionCounter = 0;
    private bool begin = false;
    private string search;
    private float target = 0.0f;
    GameObject bs;

    private void Awake()
    {
        bs = GameObject.Find("Black_Screen");
        bs.GetComponent<Image>().CrossFadeAlpha(0.0f, 2.0f, false);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.5f && !begin && positionCounter == 0)
        {
            begin = true;
            timer = 0.0f;
            search = "Pos (" + positionCounter + ")";
            target = getNextTargetTime();
        }

        if (begin)
        {
            // every 5 seconds move camera to next position
            if (timer >= target && positionCounter <= 17)
            {
                target = getNextTargetTime();
                positionCounter++;
                search = "Pos (" + positionCounter + ")";
                timer = 0.0f;
            }

            Vector3 pos = GameObject.Find(search).transform.position;
            pos.z = this.transform.position.z;
            this.transform.position = Vector3.Lerp(this.transform.position, pos, 1.0f*Time.deltaTime);

            
        }

        if (positionCounter == 18)
        {
            if (timer >= 5.0f && begin)
            { 
                begin = false; 
                bs.GetComponent<Image>().CrossFadeAlpha(1.0f, 2.0f, false);
            }
            else if (timer >= 10.0f)
            {
                nextLevel();
                positionCounter = 99;   
            }

        }
    }

    private float getNextTargetTime()
    {
        switch (positionCounter)
        {
            case 0: return 5.0f;
            case 1: return 5.0f; 
            case 2: return 5.0f;
            case 3: return 5.0f;
            case 4: return 10.0f;
            case 5: return 5.0f;
            case 6: return 10.0f;
            case 7: return 5.0f;
            case 8: return 10.0f;
            case 9: return 3.0f;
            case 10: return 3.0f;
            case 11: return 3.0f;
            case 12: return 3.0f;
            case 13: return 3.0f;
            case 14: return 15.0f;
            case 15: return 15.0f;
            case 16: return 7.0f;
            case 17: return 5.0f;
            
        }



        return 0.0f;
    }

    private void nextLevel()
    {
        gameObject.GetComponent<SwapScenes>().loadLevel1();
    }
}
