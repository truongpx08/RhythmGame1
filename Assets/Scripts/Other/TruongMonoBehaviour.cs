using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class TruongMonoBehaviour : MonoBehaviour
{
    [Button]
    protected virtual void Reset()
    {
        LoadComponents();
        ResetValue();
    }

    protected virtual void Awake()
    {
        LoadComponents();
    }

    protected virtual void LateUpdate()
    {
    }

    protected virtual void LoadComponents()
    {
        //For override
    }

    protected virtual void ResetValue()
    {
        //For override
    }
}