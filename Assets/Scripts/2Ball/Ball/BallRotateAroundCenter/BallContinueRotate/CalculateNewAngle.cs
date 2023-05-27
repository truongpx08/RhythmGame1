using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CalculateNewAngle : MonoBehaviour
{
    [Button]
    public float Calculate(Direction targetDirection)
    {
        float angle = 0;
        switch (targetDirection)
        {
            case Direction.Up:
                angle = Mathf.PI / 2; //up
                break;
            case Direction.Down:
                angle = -Mathf.PI / 2; //down
                break;
            case Direction.Left:
                angle = Mathf.PI; //left
                break;
            case Direction.Right:
                angle = 0; //right
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(targetDirection), targetDirection, null);
        }

        return angle;
    }
}