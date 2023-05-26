using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class DespawnParent : Despawn
{
    [Button]
    protected override void DespawnObject()
    {
        BoxSpawner.Instance.Despawn(transform.parent);
    }

    protected override bool CanDespawn()
    {
        return PlayController.Instance.isCompleted;
    }
}