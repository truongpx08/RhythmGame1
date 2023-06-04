using System;
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
    [SerializeField] protected Transform center;

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

    protected override void SetDefaultValue()
    {
        base.SetDefaultValue();
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

    protected void Rotate()
    {
        if (!canRotate) return;
        RotateAroundCenter(center.transform.position);
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

    protected void RotateAroundCenter(Vector3 centerPosition)
    {
        CalculatorAngle();
        var x = centerPosition.x + radius * Mathf.Cos(angle);
        var y = centerPosition.y + radius * Mathf.Sin(angle);
        transform.parent.transform.position = new Vector3(x, y, 0);
    }

    protected void CalculatorAngle()
    {
        if (twoBall.TwoBallAbilities.TwoBallReverser.IsReverse)
            angle += GetCurrentSpeed() * Time.deltaTime;
        else
            angle -= GetCurrentSpeed() * Time.deltaTime;
    }

    protected float GetCurrentSpeed()
    {
        return speed * twoBall.TwoBallAbilities.TwoBallSpeedUp.XSpeed *
               twoBall.TwoBallAbilities.TwoBallSpeedDown.XSpeed;
    }
}