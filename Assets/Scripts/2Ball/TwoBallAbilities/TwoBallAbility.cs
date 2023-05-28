using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class TwoBallAbility : TruongMonoBehaviour
{
    [SerializeField] protected int amount;

    protected override void ResetValue()
    {
        base.ResetValue();
        amount = 0;
    }

    [Button]
    public virtual void Effect()
    {
        amount++;
    }
}