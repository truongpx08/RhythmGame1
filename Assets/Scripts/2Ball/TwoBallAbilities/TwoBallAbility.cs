using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class TwoBallAbility : TruongMonoBehaviour
{
    [SerializeField] protected int amount;
    public int Amount => amount;

    protected override void SetDefaultValue()
    {
        base.SetDefaultValue();
        ResetAmount();
    }

    [Button]
    public virtual void Effect()
    {
        amount++;
    }

    [Button]
    public virtual void ResetAmount()
    {
        amount = 0;
    }

    public bool isMaxAmount => amount >= 3;
}