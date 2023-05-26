using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Circle2RotateAroundCenter : CircleRotateAroundCenter
{
    [SerializeField] protected bool isRotating;
    public bool IsRotating => isRotating;

    protected override void RotateAroundCenter()
    {
        var isPause = twoCircleController.Circle2.CircleStop.IsPause;
        isRotating = isPause;
        if (isPause) return;
        var centerPos = twoCircleController.Circle1.transform.position;
        angle -= speed * Time.deltaTime;
        var x = centerPos.x + radius * Mathf.Cos(angle);
        var y = centerPos.y + radius * Mathf.Sin(angle);
        transform.parent.transform.position = new Vector3(x, y, 0);
    }
}