using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NextLevelButton : MonoBehaviour
{
    
    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(CallLevelManager));
    }

    public void CallLevelManager()
    {
        if (FindObjectOfType<LevelManager>() != null)
        {
            FindObjectOfType<LevelManager>().MoveToNextLevel();
        }
        else
        {
            Debug.LogWarning("Youre in dev mode");
        }
    }

}
