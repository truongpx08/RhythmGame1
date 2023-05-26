using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Ball1RotateAroundCenter : BallRotateAroundCenter
{
    protected override void Rotate()
    {
        var isPause = twoBall.Ball1.BallStop.IsPause;
        isRotating = !isPause;
        if (isPause) return;
        RotateAroundCenter(twoBall.Ball2.transform.position);
    }
}