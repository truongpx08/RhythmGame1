using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Ball1RotateAroundCenter : BallRotateAroundCenter
{
    protected override void RotateAroundCenter()
    {
        if (twoBallController.Ball1.BallStop.IsPause) return;
        angle -= speed * Time.deltaTime;
        var centerPos = twoBallController.Ball2.transform.position;
        var x = centerPos.x + radius * Mathf.Cos(angle);
        var y = centerPos.y + radius * Mathf.Sin(angle);
        transform.parent.transform.position = new Vector3(x, y, 0);
    }
}