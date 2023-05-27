using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Ball2AutoRotateAroundCenter : BallAutoRotateAroundCenter
{
    protected override void ResetValue()
    {
        base.ResetValue();
        canRotate = true;
    }

    protected override void Rotate()
    {
        if (!canRotate) return;
        RotateAroundCenter(twoBall.Ball1.transform.position);
    }
}