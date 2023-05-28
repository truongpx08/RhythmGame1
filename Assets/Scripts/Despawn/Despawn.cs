using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class Despawn : TruongMonoBehaviour
{
    protected virtual void FixedUpdate()
    {
        Depawning();
    }

    private void Depawning()
    {
        if (!CanDespawn()) return;
        DespawnObject();
    }

    public virtual void DespawnObject()
    {
        //For override
    }

    protected virtual bool CanDespawn()
    {
        return false;
        //For override
    }
}