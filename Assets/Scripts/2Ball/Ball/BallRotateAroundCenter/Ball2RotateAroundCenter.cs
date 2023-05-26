using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Ball2RotateAroundCenter : BallRotateAroundCenter
{
    [SerializeField] protected bool isRotating;
    public bool IsRotating => isRotating;

    protected override void RotateAroundCenter()
    {
        var isPause = twoBallController.Ball2.BallStop.IsPause;
        isRotating = isPause;
        if (isPause) return;
        var centerPos = twoBallController.Ball1.transform.position;
        angle -= speed * Time.deltaTime;
        var x = centerPos.x + radius * Mathf.Cos(angle);
        var y = centerPos.y + radius * Mathf.Sin(angle);
        transform.parent.transform.position = new Vector3(x, y, 0);
    }
}