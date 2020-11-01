using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity;

public class LevelManager : MonoBehaviour
{

    private string currentLevel;
    //THESE SHOULD ONLY BE SCENES GOING IN HERE
    public Object[] levels;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    
    public void MoveToNextLevel()
    {
        int index = FindIndexOfLevel(currentLevel);
        if (index + 1 == levels.Length)
        {
            //Load final win screen here
        }
        else
        {
            SceneManager.LoadScene(levels[index + 1].name);
        }
    }

    public void LoadLevelAtIndex(int index)
    {
        SceneManager.LoadScene(levels[index].name);
    }

    public void RetryCurrentLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }

    private int FindIndexOfLevel(string levelName)
    {
        for (int i = 0; i < levels.Length; i++)
        {
            if(levelName == levels[i].name)
            {
                return i;
            }
        }
        Debug.LogError("Couldn't find next level");
        return -1;
    }

    public void SetCurrentLevel(string levelName)
    {
        currentLevel = levelName;
    }

    public void GoToMainMenu()
    {
       SceneManager.LoadScene("StartScreen");
    }
}
