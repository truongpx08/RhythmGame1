using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BallContinueRotate : TruongMonoBehaviour
{
    [Button]
    public virtual void ContinueRotation()
    {
        //For override  
    }

    [Button]
    protected virtual float CalculateNewAngle(Vector3 centerPos, Vector3 targetPos)
    {
        float angle = 0;
        var deltaX = centerPos.x - targetPos.x;
        var deltaY = centerPos.y - targetPos.y;
        Debug.Log($"{centerPos.x} {centerPos.y} {targetPos.x} {targetPos.y}");
        if (deltaY < 0)
            angle = -Mathf.PI / 2; //down
        else if (deltaY > 0)
            angle = Mathf.PI / 2; //up
        else if (deltaX < 0)
            angle = Mathf.PI; //left
        else if (deltaX > 0)
            angle = 0; //right
        // CameraController.Instance.Follow(centerPoint);

        Debug.Log("Angle: " + angle);
        return angle;
    }
}