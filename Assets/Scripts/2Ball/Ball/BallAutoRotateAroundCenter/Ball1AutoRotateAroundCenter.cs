using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Ball1AutoRotateAroundCenter : BallAutoRotateAroundCenter
{
    protected override void SetDefaultValue()
    {
        base.SetDefaultValue();
        canRotate = false;
        center = FindObjectOfType<TwoBall>().Ball2.transform;
    }
}