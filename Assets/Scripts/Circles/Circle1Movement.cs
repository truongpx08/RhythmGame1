using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Circle1Movement : CircleMovement
{
    protected override void RotateAroundCenter()
    {
        if (isPause) return;
        angle -= speed * Time.deltaTime;
        var centerPos = CirclesController.Instance.CenterObject.transform.position;
        var x = centerPos.x + radius * Mathf.Cos(angle);
        var y = centerPos.y + radius * Mathf.Sin(angle);
        transform.parent.transform.position = new Vector3(x, y, 0);
    }
}