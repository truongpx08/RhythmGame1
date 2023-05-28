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
    [SerializeField] protected BallGetAbilityFromBox ballGetAbilityFromBox;
    public BallGetAbilityFromBox BallGetAbilityFromBox => ballGetAbilityFromBox;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBallRotateAroundCenter();
        LoadBallTransferToBox();
        LoadBallGetAbilityFromBox();
    }

    protected void LoadBallGetAbilityFromBox()
    {
        ballGetAbilityFromBox = transform.Find("BallGetAbilityFromBox").GetComponent<BallGetAbilityFromBox>();
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