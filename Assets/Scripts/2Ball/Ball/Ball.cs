using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class Ball : TwoBallAbstract
{
    [SerializeField] protected BallAutoRotateAroundCenter ballAutoRotateAroundCenter;
    public BallAutoRotateAroundCenter BallAutoRotateAroundCenter => ballAutoRotateAroundCenter;

    [SerializeField] protected BallTransferToBox ballTransferToBox;
    public BallTransferToBox BallTransferToBox => ballTransferToBox;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBallRotateAroundCenter();
        LoadBallTransferToBox();
    }

    protected void LoadBallRotateAroundCenter()
    {
        ballAutoRotateAroundCenter =
            transform.Find("BallAutoRotateAroundCenter").GetComponent<BallAutoRotateAroundCenter>();
    }


    private void LoadBallTransferToBox()
    {
        ballTransferToBox = transform.Find("BallTransferToBox").GetComponent<BallTransferToBox>();
    }
}