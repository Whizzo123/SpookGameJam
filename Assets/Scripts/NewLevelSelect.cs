using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NewLevelSelect : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("FirstLevel");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("SecondLevel");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("ThirdLevel");
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene("FourthLevel");
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene("FifthLevel");
    }
}
