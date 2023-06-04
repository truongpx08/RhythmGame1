using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BoxUnlockHandler : BoxAbstract
{
    [SerializeField] protected bool isLock;
    public bool IsLock => isLock;

    protected override void SetDefaultValue()
    {
        base.SetDefaultValue();
        isLock = true;
        box.BoxModel.BoxModelColor.SetColor(Color.gray);
    }

    [Button]
    public void Unlock()
    {
        isLock = false;
        box.BoxModel.BoxModelColor.SetColor(Color.white);
    }
}