using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour
{
   
    public void StartPlay()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void ExitGame()
    {
        Application.Quit(0);
    }

}
