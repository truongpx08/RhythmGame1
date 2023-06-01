using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public void LoopGame(Ball ballRotating, Box targetBox)
    {
        ballRotating.BallAutoRotateAroundCenter.BallStopRotate.Stop();
        ballRotating.BallTransferToBox.TransferToBox(targetBox);

        var ballCenter = TwoBall.Instance.GetBallCenter();
        ballCenter.BallGetAbilityFromBox.GetAbilityFromBox(targetBox);
        ballCenter.BallAutoRotateAroundCenter.BallContinueRotate.ContinueRotation();

        BoxHolder.Instance.BoxHolderTargetBox.SetTargetBox();
    }
}