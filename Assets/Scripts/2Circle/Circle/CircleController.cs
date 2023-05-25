using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class CircleController : TwoCircleAbstract
{
    [SerializeField] protected CircleRotateAroundCenter circleRotateAroundCenter;
    public CircleRotateAroundCenter CircleRotateAroundCenter => circleRotateAroundCenter;
    [SerializeField] protected CircleStop circleStop;
    public CircleStop CircleStop => circleStop;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMovement();
        LoadStop();
    }

    protected void LoadMovement()
    {
        circleRotateAroundCenter = transform.Find("RotateAroundCenter").GetComponent<CircleRotateAroundCenter>();
    }

    protected void LoadStop()
    {
        circleStop = transform.Find("Stop").GetComponent<CircleStop>();
    }
}