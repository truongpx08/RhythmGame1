using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CircleHolderAbstract : TruongMonoBehaviour
{
    [SerializeField] protected CircleHolderController circleHolderController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCircleHolderController();
    }

    protected void LoadCircleHolderController()
    {
        circleHolderController = transform.parent.GetComponent<CircleHolderController>();
    }
}