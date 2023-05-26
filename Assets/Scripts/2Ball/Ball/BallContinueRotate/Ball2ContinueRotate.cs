using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2ContinueRotate : BallContinueRotate
{
    public override void ContinueRotation()
    {
        var newAngle = CalculateNewAngle(TwoBall.Instance.Ball2.transform.position,
            TwoBall.Instance.Ball1.transform.position);
        TwoBall.Instance.Ball2.BallRotateAroundCenter.ResetAngle(newAngle);
    }
}