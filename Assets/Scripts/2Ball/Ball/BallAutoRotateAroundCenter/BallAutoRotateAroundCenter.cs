using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class BallAutoRotateAroundCenter : TwoBallAbstract
{
    public bool IsRotating => isRotating;
    [SerializeField] protected BallStopRotate ballStopRotate;
    public BallStopRotate BallStopRotate => ballStopRotate;
    [SerializeField] protected BallContinueRotate ballContinueRotate;
    public BallContinueRotate BallContinueRotate => ballContinueRotate;


    [SerializeField] protected float angle;
    [SerializeField] protected float radius;
    [SerializeField] protected float speed;
    [SerializeField] protected bool isRotating;
    [SerializeField] protected bool canRotate;

    public bool CanRotate
    {
        get => canRotate;
        set => canRotate = value;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBallRotate();
        LoadBallContinueRotate();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        angle = -Mathf.PI / 2;
        radius = 0.4f;
        speed = 4f;
        isRotating = false;
    }

    private void Update()
    {
        SetIsRotating();
        Rotate();
    }


    protected void LoadBallRotate()
    {
        ballStopRotate = transform.Find("BallStopRotate").GetComponent<BallStopRotate>();
    }

    protected void LoadBallContinueRotate()
    {
        ballContinueRotate = transform.Find("BallContinueRotate").GetComponent<BallContinueRotate>();
    }


    [Button]
    public void ResetAngle(float value)
    {
        angle = value;
    }

    protected void SetIsRotating()
    {
        isRotating = canRotate;
    }

    [Button]
    protected virtual void Rotate()
    {
        // For override
    }

    protected void RotateAroundCenter(Vector3 centerPosition)
    {
        CalculatorAngle();
        var x = centerPosition.x + radius * Mathf.Cos(angle);
        var y = centerPosition.y + radius * Mathf.Sin(angle);
        transform.parent.transform.position = new Vector3(x, y, 0);
    }

    protected void CalculatorAngle()
    {
        if (twoBall.TowBallReverser.IsReverse)
            angle += speed * Time.deltaTime;
        else
            angle -= speed * Time.deltaTime;
    }
}