using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class TwoCircleAbstract : TruongMonoBehaviour
{
    [SerializeField] protected TwoBallController twoBallController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCirclesController();
    }

    protected void LoadCirclesController()
    {
        twoBallController = FindObjectOfType<TwoBallController>();
    }
}