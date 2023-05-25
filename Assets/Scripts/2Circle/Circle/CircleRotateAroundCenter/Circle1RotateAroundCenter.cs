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

    protected override void CalculateOriginalAngle()
    {
        var centerPos = twoCircleController.Circle2.transform.position;
        // Xác định vector hướng từ vật thể A đến vật thể B
        Vector3 direction = centerPos - transform.position;

        // Tính toán góc dựa trên vị trí của vật B so với vật A
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // In góc ra console để kiểm tra
        Debug.Log("Góc của vật B: " + angle);
    }
}