using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CircleAbstract : TwoCircleAbstract
{
    [SerializeField] protected BallController ballController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCirclesController();
    }

    protected void LoadCirclesController()
    {
        ballController = transform.parent.GetComponent<BallController>();
    }
}