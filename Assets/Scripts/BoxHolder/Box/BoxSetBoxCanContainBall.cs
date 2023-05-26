using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BoxSetBoxCanContainBall : MonoBehaviour
{
    [SerializeField] protected Box currentBoxCanContainBall;
    public Box CurrentBoxCanContainBall => currentBoxCanContainBall;

    [Button]
    public void SetBoxCanContainBall(Box newBox)
    {
        currentBoxCanContainBall = newBox;
        currentBoxCanContainBall.BoxAllowContainBall.Allow();
    }
}