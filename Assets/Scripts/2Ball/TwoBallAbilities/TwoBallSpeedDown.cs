using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class TwoBallSpeedDown : TwoBallSpeedChange
{
    [Button]
    public override void Effect()
    {
        base.Effect();
        xSpeed /= 1.5f;
    }
}