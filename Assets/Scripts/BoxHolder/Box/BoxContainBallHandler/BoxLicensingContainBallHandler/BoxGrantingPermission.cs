using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BoxGrantingPermission : BoxAbstract
{
    [SerializeField] protected bool isGranting;
    public bool IsGranting => isGranting;

    protected override void SetDefaultValue()
    {
        base.SetDefaultValue();
        isGranting = false;
    }

    [Button]
    public void Granting()
    {
        isGranting = true;
    }

    [Button]
    public void Denying()
    {
        isGranting = false;
        box.BoxModel.BoxModelColor.SetColor(Color.red);
    }
}