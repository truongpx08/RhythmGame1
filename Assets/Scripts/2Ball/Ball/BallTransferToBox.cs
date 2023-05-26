using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class BallTransferToBox : BallAbstract
{
    [SerializeField] protected float distanceLimit;

    protected override void ResetValue()
    {
        base.ResetValue();
        distanceLimit = 0.2f;
    }

    private void Update()
    {
        Transferring();
    }

    protected void Transferring()
    {
        if (!ball.BallRotateAroundCenter.IsRotating || !InputManager.Instance.IsKeyDown) return;
        var currentBox = BoxHolder.Instance.BoxSetBoxCanContainBall.CurrentBoxCanContainBall;
        if (IsPass(transform.parent.transform.position,
                currentBox.transform.position))
        {
            TransferToBox();
            currentBox.BoxContainBall.Contain();
        }
        else
        {
            Debug.LogError("Game Over");
        }
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