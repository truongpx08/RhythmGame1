using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class BallContinueRotate : BallAutoRotateAroundCenterAbstract
{
    [SerializeField] protected CalculateDirection calculateDirection;
    [SerializeField] protected CalculateNewAngle calculateNewAngle;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCalculateDirection();
        LoadCalculateNewAngle();
    }

    private void LoadCalculateDirection()
    {
        calculateDirection = transform.Find("CalculateDirection").GetComponent<CalculateDirection>();
    }

    private void LoadCalculateNewAngle()
    {
        calculateNewAngle = transform.Find("CalculateNewAngle").GetComponent<CalculateNewAngle>();
    }

    [Button]
    protected internal void ContinueRotation()
    {
        var dir = calculateDirection.Calculate(
            BoxHolder.Instance.BoxHolderCenterBox.CenterBox.transform.position,
            BoxHolder.Instance.BoxHolderTargetBox.TargetBox.transform.position);
        var newAngle = calculateNewAngle.Calculate(dir);
        ballAutoRotateAroundCenter.ResetAngle(newAngle);
        Continue();
    }

    [Button]
    public void Continue()
    {
        ballAutoRotateAroundCenter.CanRotate = true;
    }
}