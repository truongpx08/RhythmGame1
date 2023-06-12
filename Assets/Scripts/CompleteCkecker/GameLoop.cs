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


        BoxHolder.Instance.BoxHolderCenterBox.SetCenterBox(BoxHolder.Instance.BoxHolderTargetBox.TargetBox);
        BoxHolder.Instance.BoxHolderTargetBox.SetTargetBox(GetNextBox());
    }

    private Box GetNextBox()
    {
        var nextBox = TryGetNextBox();
        if (nextBox == null)
        {
            BoxSpawner.Instance.SpawnBoxes();
            nextBox = TryGetNextBox();
        }

        return nextBox;
    }

    private Box TryGetNextBox()
    {
        var targetBox = BoxHolder.Instance.BoxHolderTargetBox.TargetBox;
        return BoxSpawner.Instance.Boxes.Find(b =>
            b.BoxId.Id ==
            targetBox.BoxId.Id + 1);
    }
}