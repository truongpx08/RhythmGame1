using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class Ball1TransferToBox : BallTransferToBox
{
    protected override void Transferring()
    {
        if (!ball.BallRotateAroundCenter.IsRotating || !InputManager.Instance.IsKeyDown) return;
        var currentBox = BoxHolder.Instance.BoxSetBoxCanContainBall.CurrentBoxCanContainBall;
        if (IsPass(transform.parent.transform.position,
                currentBox.transform.position))
        {
            TransferToBox();
            currentBox.BoxContainBall.Contain();
            twoBall.Ball2.BallContinueRotate.ContinueRotation();
        }
        else
        {
            Debug.LogError("Game Over");
        }
    }
}