using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class TwoBallReverser : TwoBallAbility
{
    [SerializeField] protected bool isReverse;
    public bool IsReverse => isReverse;

    protected override void SetDefaultValue()
    {
        base.SetDefaultValue();
        isReverse = false;
    }


    [Button]
    public override void Effect()
    {
        base.Effect();
        isReverse = !isReverse;
    }
}