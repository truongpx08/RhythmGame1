using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BoxAllowContainBall : BoxAbstract
{
    [SerializeField] protected bool isAllow;
    public bool IsAllow => isAllow;

    protected override void ResetValue()
    {
        base.ResetValue();
        isAllow = false;
    }

    [Button]
    public void Allow()
    {
        isAllow = true;
        // box.BoxSetColorModel.SetColor(Color.white);
    }

    [Button]
    public void DoNotAllow()
    {
        isAllow = false;
        box.BoxSetColorModel.SetColor(Color.red);
    }
}