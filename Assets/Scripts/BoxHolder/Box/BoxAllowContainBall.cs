using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAllowContainBall : TruongMonoBehaviour
{
    [SerializeField] protected bool isAllow;
    public bool IsAllow => isAllow;

    protected override void ResetValue()
    {
        base.ResetValue();
        isAllow = false;
    }

    public void Allow()
    {
        isAllow = true;
    }
}