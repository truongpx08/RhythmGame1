using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class TwoBallSpeedChange : TwoBallAbility
{
    [SerializeField] protected float xSpeed;
    public float XSpeed => xSpeed;

    protected override void ResetValue()
    {
        base.ResetValue();
        ResetXSpeed();
    }

    public void ResetXSpeed()
    {
        xSpeed = 1;
    }

    [Button]
    public override void Effect()
    {
        base.Effect();
    }
}