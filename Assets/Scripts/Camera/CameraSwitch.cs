using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


public class CameraSwitch : MonoBehaviour
{


    public Camera HellCamera, HeavanCamera;
    public KeyCode SpaceKey;
    public bool camSwitch = false;

    void Update()
    {
        if (Input.GetKeyDown(SpaceKey))
        {
            camSwitch = !camSwitch;
            HellCamera.gameObject.SetActive(camSwitch);
            HeavanCamera.gameObject.SetActive(!camSwitch);


        }
    }
}
