using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class BallTransferToBox : BallAbstract
{
    private void Update()
    {
        Transferring();
    }

    protected virtual void Transferring()
    {
        //For override
    }

    protected void TransferToBox()
    {
        transform.parent.transform.position =
            BoxHolder.Instance.BoxSetBoxCanContainBall.CurrentBoxCanContainBall.transform.position;
    }

    protected bool IsPass(Vector3 ballPosition, Vector3 boxPosition)
    {
        return Vector3.Distance(ballPosition, boxPosition) < PlayController.Instance.Config.distanceLimit;
    }
}