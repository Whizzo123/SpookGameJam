using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{


    public Camera myCamera;

    public void SetCameraShowing(Camera camera)
    {
        this.myCamera = camera;
    }

}
