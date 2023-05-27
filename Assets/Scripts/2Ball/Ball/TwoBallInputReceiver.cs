using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoBallInputReceiver : TwoBallAbstract
{
    private void Update()
    {
        if (InputManager.Instance.IsKeyDown)
        {
            var targetBox = BoxHolder.Instance.BoxHolderSetTargetBox.TargetBox;
            if (twoBall.Ball1.BallAutoRotateAroundCenter.IsRotating)
            {
                OnStop(twoBall.Ball1, targetBox);
                OnRotate(twoBall.Ball2);
            }
            else if (twoBall.Ball2.BallAutoRotateAroundCenter.IsRotating)
            {
                OnStop(twoBall.Ball2, targetBox);
                OnRotate(twoBall.Ball1);
            }
            else
            {
                Debug.LogError("TwoBall Input is error");
            }

            BoxHolder.Instance.BoxHolderSetTargetBox.SetTargetBox();
        }
    }

    private void OnRotate(Ball ball)
    {
        ball.BallAutoRotateAroundCenter.BallContinueRotate.ContinueRotation();
    }

    private void OnStop(Ball ball, Box targetBox)
    {
        ball.BallAutoRotateAroundCenter.BallStopRotate.Stop();
        ball.BallTransferToBox.TransferToBox(targetBox);
        CameraController.Instance.Follow(ball.transform);
    }
}