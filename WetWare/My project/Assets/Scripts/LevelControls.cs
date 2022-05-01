using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControls : MonoBehaviour
{
   
    public void startGame()
    {
        SceneManager.LoadScene("Comic1");
    }

    public void restartLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
