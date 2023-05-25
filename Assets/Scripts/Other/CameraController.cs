using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Pixelplacement;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    public new CinemachineVirtualCamera camera;

    public void Follow(Transform obj)
    {
        camera.Follow = obj;
    }
}