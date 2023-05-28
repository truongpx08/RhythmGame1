using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public void LoopGame(Ball ballRotating, Box targetBox)
    {
        ballRotating.BallAutoRotateAroundCenter.BallStopRotate.Stop();
        ballRotating.BallTransferToBox.TransferToBox(targetBox);

        var ballCenter = GetBallCenter();
        ballCenter.BallGetAbilityFromBox.GetAbilityFromBox(targetBox);
        ballCenter.BallAutoRotateAroundCenter.BallContinueRotate.ContinueRotation();

        BoxHolder.Instance.BoxHolderSetTargetBox.SetTargetBox();
    }

    protected Ball GetBallCenter()
    {
        var twoBall = TwoBall.Instance;
        return twoBall.Ball1.BallAutoRotateAroundCenter.IsRotating ? twoBall.Ball2 : twoBall.Ball1;
    }
}