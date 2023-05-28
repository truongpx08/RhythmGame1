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
        center = FindObjectOfType<TwoBall>().Ball1.transform;
    }
}