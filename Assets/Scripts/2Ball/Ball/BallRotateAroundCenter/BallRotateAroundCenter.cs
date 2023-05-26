using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BallRotateAroundCenter : TwoCircleAbstract
{
    [SerializeField] protected float angle;
    [SerializeField] protected float radius;
    [SerializeField] protected float speed;

    protected override void ResetValue()
    {
        base.ResetValue();
        angle = -Mathf.PI / 2;
        radius = 0.4f;
        speed = 4f;
    }

    [Button]
    protected virtual void CalculateOriginalAngle()
    {
        // For override
    }

    private void Update()
    {
        RotateAroundCenter();
    }

    [Button]
    protected virtual void RotateAroundCenter()
    {
        // For override
    }
}