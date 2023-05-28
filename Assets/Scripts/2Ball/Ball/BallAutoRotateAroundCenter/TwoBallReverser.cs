using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class TwoBallReverser : TruongMonoBehaviour
{
    protected override void ResetValue()
    {
        base.ResetValue();
        isReverse = false;
    }

    [SerializeField] protected bool isReverse;
    public bool IsReverse => isReverse;

    [Button]
    public void Reverse()
    {
        isReverse = !isReverse;
    }
}