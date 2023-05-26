using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class TwoBallAbstract : TruongMonoBehaviour
{
    [SerializeField] protected TwoBall twoBall;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        Load2BallController();
    }

    protected void Load2BallController()
    {
        twoBall = FindObjectOfType<TwoBall>();
    }
}