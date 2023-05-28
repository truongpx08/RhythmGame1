using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class BoxAbstract : TruongMonoBehaviour
{
    [SerializeField] protected Box box;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCircleHolderController();
    }

    protected void LoadCircleHolderController()
    {
        box = transform.parent.GetComponent<Box>();
    }
}