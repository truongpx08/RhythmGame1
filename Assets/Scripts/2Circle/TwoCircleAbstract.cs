using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class TwoCircleAbstract : TruongMonoBehaviour
{
    [SerializeField] protected TwoCircleController twoCircleController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCirclesController();
    }

    protected void LoadCirclesController()
    {
        twoCircleController = FindObjectOfType<TwoCircleController>();
    }
}