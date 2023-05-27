using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class BoxContainBall : BoxAbstract
{
    [SerializeField] protected bool isContained;
    public bool IsContained => isContained;

    protected override void ResetValue()
    {
        base.ResetValue();
        isContained = false;
    }

    [Button]
    public void Contain()
    {
        isContained = true;
    }
}