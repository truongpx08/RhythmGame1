using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassABoxChecker : TruongMonoBehaviour
{
    public bool IsPassABox(Ball ballRotating, Box targetBox)
    {
        Vector3 ballPosition = ballRotating.transform.position;
        Vector3 boxPosition = targetBox.transform.position;
        return Vector3.Distance(ballPosition, boxPosition) < PlayController.Instance.Config.distanceLimit;
    }
}