using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class TwoBallSpeedUp : TwoBallSpeedChange
{
    [Button]
    public override void Effect()
    {
        base.Effect();
        xSpeed *= deltaSpeed;
        if (!isMaxAmount || !TwoBall.Instance.TwoBallAbilities.TwoBallSpeedDown.isMaxAmount) return;
        Reset();
    }

    protected void Reset()
    {
        ResetAmount();
        ResetXSpeed();
        TwoBall.Instance.TwoBallAbilities.TwoBallSpeedUp.ResetAmount();
        TwoBall.Instance.TwoBallAbilities.TwoBallSpeedUp.ResetXSpeed();
    }
}