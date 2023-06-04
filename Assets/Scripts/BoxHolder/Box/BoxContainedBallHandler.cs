using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class BoxContainedBallHandler : BoxAbstract
{
    [SerializeField] protected bool isContained;
    public bool IsContained => isContained;

    protected override void SetDefaultValue()
    {
        base.SetDefaultValue();
        isContained = false;
    }

    [Button]
    public void ContainBall()
    {
        isContained = true;
    }
}