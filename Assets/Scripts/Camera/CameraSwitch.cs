using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


public class CameraSwitch : MonoBehaviour
{


    public Camera HellCamera, HeavenCamera;
    public KeyCode SpaceKey;
    public bool camSwitch = false;

    void Start()
    {

        FindObjectOfType<CameraManager>().SetCameraShowing(HeavenCamera);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(SpaceKey))
        {
            camSwitch = !camSwitch;
            HellCamera.gameObject.SetActive(camSwitch);
            HeavenCamera.gameObject.SetActive(!camSwitch);
            if (HellCamera.gameObject.activeSelf)
            {
                FindObjectOfType<CameraManager>().SetCameraShowing(HellCamera);
            }
            else
            {
                FindObjectOfType<CameraManager>().SetCameraShowing(HeavenCamera);
            }

        }
    }
}
