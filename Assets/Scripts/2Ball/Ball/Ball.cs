using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class Ball : TwoBallAbstract
{
    [SerializeField] protected BallRotateAroundCenter ballRotateAroundCenter;
    public BallRotateAroundCenter BallRotateAroundCenter => ballRotateAroundCenter;
    [SerializeField] protected BallStop ballStop;
    public BallStop BallStop => ballStop;

    [SerializeField] protected BallContinueRotate ballContinueRotate;
    public BallContinueRotate BallContinueRotate => ballContinueRotate;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBall1TransferToBox();
        LoadBallStop();
        LoadBallContinueRotate(); 
    }

    protected void LoadBall1TransferToBox()
    {
        ballRotateAroundCenter = transform.Find("BallRotateAroundCenter").GetComponent<BallRotateAroundCenter>();
    }

    protected void LoadBallStop()
    {
        ballStop = transform.Find("BallStop").GetComponent<BallStop>();
    }

    protected void LoadBallContinueRotate()
    {
        ballContinueRotate = transform.Find("BallContinueRotate").GetComponent<BallContinueRotate>();
    }
}