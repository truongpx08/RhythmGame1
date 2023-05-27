using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CalculateDirection : MonoBehaviour
{
    [Button]
    public virtual Direction Calculate(Vector3 centerPos, Vector3 targetPos)
    {
        Direction direction = 0;
        var deltaX = centerPos.x - targetPos.x;
        var deltaY = centerPos.y - targetPos.y;
        var disLimit = PlayController.Instance.Config.distanceLimit;
        if (deltaY < -disLimit)
            direction = Direction.Down;
        else if (deltaY > disLimit)
            direction = Direction.Up;
        else if (deltaX > disLimit)
            direction = Direction.Right;
        else if (deltaX < -disLimit)
            direction = Direction.Left;

        return direction;
    }
}