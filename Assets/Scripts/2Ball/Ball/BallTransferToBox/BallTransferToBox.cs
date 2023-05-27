using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class BallTransferToBox : BallAbstract
{
    public void TransferToBox(Box boxTarget)
    {
        transform.parent.transform.position = boxTarget.transform.position;
    }
    protected bool IsPass(Vector3 ballPosition, Vector3 boxPosition)
    {
        return Vector3.Distance(ballPosition, boxPosition) < PlayController.Instance.Config.distanceLimit;
    }
}