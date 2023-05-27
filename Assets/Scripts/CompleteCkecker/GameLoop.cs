using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public void LoopGame(Ball ballRotating, Box targetBox)
    {
        ballRotating.BallAutoRotateAroundCenter.BallStopRotate.Stop();
        ballRotating.BallTransferToBox.TransferToBox(targetBox);

        var twoBall = TwoBall.Instance;
        var ballCenter = twoBall.Ball1.BallAutoRotateAroundCenter.IsRotating ? twoBall.Ball2 : twoBall.Ball1;
        ballCenter.BallAutoRotateAroundCenter.BallContinueRotate.ContinueRotation();

        BoxHolder.Instance.BoxHolderSetTargetBox.SetTargetBox();
    }
}