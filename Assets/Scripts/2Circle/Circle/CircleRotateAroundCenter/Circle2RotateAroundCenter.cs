using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Circle2RotateAroundCenter : CircleRotateAroundCenter
{
    protected override void RotateAroundCenter()
    {
        if (twoCircleController.Circle2.CircleStop.IsPause) return;
        var centerPos = twoCircleController.Circle1.transform.position;
        angle -= speed * Time.deltaTime;
        var x = centerPos.x + radius * Mathf.Cos(angle);
        var y = centerPos.y + radius * Mathf.Sin(angle);
        transform.parent.transform.position = new Vector3(x, y, 0);
    }

    protected override void CalculateOriginalAngle()
    {
        var centerPos = twoCircleController.Circle1.transform.position;
        Vector3 direction = centerPos - transform.position;
        angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        // Debug.Log(angle);
        var angleInPi = angle / Mathf.PI;
        Debug.Log(angleInPi);
    }
}