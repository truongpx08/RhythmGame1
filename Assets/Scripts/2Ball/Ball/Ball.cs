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

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMovement();
        LoadStop();
    }

    protected void LoadMovement()
    {
        ballRotateAroundCenter = transform.Find("BallRotateAroundCenter").GetComponent<BallRotateAroundCenter>();
    }

    protected void LoadStop()
    {
        ballStop = transform.Find("BallStop").GetComponent<BallStop>();
    }
}