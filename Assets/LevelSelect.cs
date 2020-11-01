using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{

    public Button[] levelButtons;
    void Awake()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int index = i;
            levelButtons[i].onClick.AddListener(delegate { LoadLevel(index); });
        }
    }

    void LoadLevel(int index)
    {
        Debug.Log("Load level of index: " + index);
        FindObjectOfType<LevelManager>().LoadLevelAtIndex(index);
    }

}
