﻿using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class BoxDoNotAllowContainBall : PassABoxChecker
{
    [SerializeField] private bool canStartCalculation;

    protected override void ResetValue()
    {
        base.ResetValue();
        canStartCalculation = false;
    }

    private void Update()
    {
        CalculatorMissing();
    }

    protected void CalculatorMissing()
    {
        if (!box.BoxAllowContainBall.IsAllow || box.BoxContainBall.IsContained) return;
        if (!canStartCalculation)
        {
            if (CanPassABox(TwoBall.Instance.GetBallRotating(), BoxHolder.Instance.BoxHolderSetTargetBox.TargetBox))
            {
                canStartCalculation = true;
            }

            return;
        }

        if (!IsMissABox(TwoBall.Instance.GetBallRotating(), BoxHolder.Instance.BoxHolderSetTargetBox.TargetBox))
            return;
        DoNotAllow();
    }

    [Button]
    public void DoNotAllow()
    {
        box.BoxAllowContainBall.DoNotAllow();
        Debug.Log("DoNotAllowa");
    }
}