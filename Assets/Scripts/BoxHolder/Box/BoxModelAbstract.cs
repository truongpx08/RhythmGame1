using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoxModelAbstract : TruongMonoBehaviour
{
    [SerializeField] protected BoxModel boxModel;
    public BoxModel BoxModel => boxModel;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
    }

    protected void LoadModel()
    {
        boxModel = transform.parent.GetComponent<BoxModel>();
    }
}