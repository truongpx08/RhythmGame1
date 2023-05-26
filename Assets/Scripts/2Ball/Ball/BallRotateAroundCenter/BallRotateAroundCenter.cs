using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BallRotateAroundCenter : TwoBallAbstract
{
    [SerializeField] protected float angle;
    [SerializeField] protected float radius;
    [SerializeField] protected float speed;
    [SerializeField] protected bool isRotating;
    public bool IsRotating => isRotating;

    protected override void ResetValue()
    {
        base.ResetValue();
        angle = -Mathf.PI / 2;
        radius = 0.4f;
        speed = 4f;
        isRotating = false;
    }

    [Button]
    protected virtual void CalculateOriginalAngle()
    {
        // For override
    }

    private void Update()
    {
        Rotate();
    }

    [Button]
    protected virtual void Rotate()
    {
        // For override
    }

    protected void RotateAroundCenter(Vector3 centerPosition)
    {
        angle -= speed * Time.deltaTime;
        var x = centerPosition.x + radius * Mathf.Cos(angle);
        var y = centerPosition.y + radius * Mathf.Sin(angle);
        transform.parent.transform.position = new Vector3(x, y, 0);
    }
}