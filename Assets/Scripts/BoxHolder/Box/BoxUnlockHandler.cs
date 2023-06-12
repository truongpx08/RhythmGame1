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
        Lock();
    }

    [Button]
    public void Lock()
    {
        isLock = true;
        box.BoxModel.BoxIcon.ShowIcon();
    }

    [Button]
    public void Unlock()
    {
        isLock = false;
        box.BoxModel.BoxIcon.HideIcon();
    }
}