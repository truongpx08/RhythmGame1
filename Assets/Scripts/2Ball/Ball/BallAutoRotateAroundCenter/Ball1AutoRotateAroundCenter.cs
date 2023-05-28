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
        center = FindObjectOfType<TwoBall>().Ball2.transform;
    }
}