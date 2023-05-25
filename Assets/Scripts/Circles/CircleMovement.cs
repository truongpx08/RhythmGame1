using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CircleMovement : TruongMonoBehaviour
{
    [SerializeField] protected float angle;
    [SerializeField] protected float radius;
    [SerializeField] protected float speed;
    [SerializeField] protected bool isPause;

    protected override void ResetValue()
    {
        base.ResetValue();
        angle = -Mathf.PI / 2;
        isPause = true;
        radius = 0.4f;
        speed = 4f;
    }

    private void Update()
    {
        RotateAroundCenter();
    }

    protected virtual void RotateAroundCenter()
    {
    }

    [Button]
    protected void Rotate()
    {
        isPause = false;
    }

    [Button]
    protected void Pause()
    {
        isPause = true;
    }
}