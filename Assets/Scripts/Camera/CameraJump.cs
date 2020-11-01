using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


public class CameraJump : MonoBehaviour
{

    
    public Camera HellCamera, HeavanCamera;
    public KeyCode QKey;
    public bool camSwitch = false;

    void Update()
    {
        if (Input.GetKeyDown(QKey))
        {
            camSwitch = !camSwitch;
            HellCamera.gameObject.SetActive(camSwitch);
            HeavanCamera.gameObject.SetActive(!camSwitch);
          
            
        }
    }
}