using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CircleAbstract : TwoCircleAbstract
{
    [SerializeField] protected CircleController circleController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCirclesController();
    }

    protected void LoadCirclesController()
    {
        circleController = transform.parent.GetComponent<CircleController>();
    }
}