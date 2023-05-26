using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Ball2RotateAroundCenter : BallRotateAroundCenter
{
    protected override void Rotate()
    {
        var isPause = twoBall.Ball2.BallStop.IsPause;
        isRotating = !isPause;
        if (isPause) return;
        RotateAroundCenter(twoBall.Ball1.transform.position);
    }
}