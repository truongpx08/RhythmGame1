using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassABoxChecker : BoxAbstract
{
    public bool IsPassABox(Ball ballRotating, Box targetBox)
    {
        return CanPassABox(ballRotating, targetBox) &&
               BoxHolder.Instance.BoxHolderSetTargetBox.TargetBox.BoxAllowContainBall.IsAllow;
    }

    public bool IsMissABox(Ball ballRotating, Box targetBox)
    {
        return !CanPassABox(ballRotating, targetBox);
    }

    public bool CanPassABox(Ball ballRotating, Box targetBox)
    {
        return Vector3.Distance(ballRotating.transform.position, targetBox.transform.position) <
               PlayController.Instance.Config.distanceLimit;
    }
}