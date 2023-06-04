using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class BoxHolderTargetBox : MonoBehaviour
{
    [SerializeField] protected Box targetBox;
    public Box TargetBox => targetBox;

    [Button]
    public void SetTargetBox(Box newBox)
    {
        targetBox = newBox;
        targetBox.BoxContainBallHandler.BoxLicensingContainBallHandler.BoxGrantingPermission.Granting();
    }
}