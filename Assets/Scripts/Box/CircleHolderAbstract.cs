using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CircleHolderAbstract : TruongMonoBehaviour
{
    [SerializeField] protected BoxController boxController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCircleHolderController();
    }

    protected void LoadCircleHolderController()
    {
        boxController = transform.parent.GetComponent<BoxController>();
    }
}