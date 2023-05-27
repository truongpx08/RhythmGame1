using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class BallAbstract : TwoBallAbstract
{
    [SerializeField] protected Ball ball;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCirclesController();
    }

    protected void LoadCirclesController()
    {
        ball = transform.parent.GetComponent<Ball>();
    }
}