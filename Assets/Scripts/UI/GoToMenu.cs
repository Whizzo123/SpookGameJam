using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMenu : MonoBehaviour
{
    public void GoToMainMenu()
    {
        FindObjectOfType<LevelManager>().GoToMainMenu();
    }

    public void RetryLevel()
    {
        FindObjectOfType<LevelManager>().RetryCurrentLevel();
    }

    public void HowToPlay()
    {
        FindObjectOfType<LevelManager>().GoToHowToPlay();
    }
}
