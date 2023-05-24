using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Despawn : TruongMonoBehaviour
{
    [Button]
    protected virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }
}