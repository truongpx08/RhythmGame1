using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoxLevelPoolAbstract : TruongMonoBehaviour
{
    [SerializeField] protected BoxLevelPool boxLevelPool;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBoxLevelPool();
    }

    private void LoadBoxLevelPool()
    {
        boxLevelPool = transform.parent.GetComponent<BoxLevelPool>();
    }
}