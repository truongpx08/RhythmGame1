using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Circle1RotateAroundCenter : CircleRotateAroundCenter
{
    protected override void RotateAroundCenter()
    {
        if (twoCircleController.Circle1.CircleStop.IsPause) return;
        angle -= speed * Time.deltaTime;
        var centerPos = twoCircleController.Circle2.transform.position;
        var x = centerPos.x + radius * Mathf.Cos(angle);
        var y = centerPos.y + radius * Mathf.Sin(angle);
        transform.parent.transform.position = new Vector3(x, y, 0);
    }
}