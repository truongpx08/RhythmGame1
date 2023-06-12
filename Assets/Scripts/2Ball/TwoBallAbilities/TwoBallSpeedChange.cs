using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class TwoBallSpeedChange : TwoBallAbility
{
    [SerializeField] protected float xSpeed;
    public float XSpeed => xSpeed;

    [SerializeField] protected float deltaSpeed;

    protected override void SetDefaultValue()
    {
        base.SetDefaultValue();
        ResetXSpeed();
    }

    public void ResetXSpeed()
    {
        xSpeed = 1;
        deltaSpeed = 1.25f;
    }

    [Button]
    public override void Effect()
    {
        base.Effect();
    }
}