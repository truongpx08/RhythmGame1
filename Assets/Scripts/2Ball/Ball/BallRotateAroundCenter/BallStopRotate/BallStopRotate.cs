using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class BallStopRotate : BallAutoRotateAroundCenterAbstract
{
    [Button]
    public void Stop()
    {
        ballAutoRotateAroundCenter.CanRotate = false;
    }
}