using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Ball1AutoRotateAroundCenter : BallAutoRotateAroundCenter
{
    protected override void ResetValue()
    {
        base.ResetValue();
        canRotate = false;
    }

    protected override void Rotate()
    {
        if (!canRotate) return;
        RotateAroundCenter(twoBall.Ball2.transform.position);
    }
}