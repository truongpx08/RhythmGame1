using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class BoxHolderSetCurrentBox : MonoBehaviour
{
    [SerializeField] protected Box currentBox;
    public Box CurrentBox => currentBox;

    [Button]
    public void SetCurrentBox(Box newBox)
    {
        currentBox = newBox;
        CameraController.Instance.Follow(currentBox.transform);
        currentBox.BoxSetColorModel.SetColor(Color.green);
        currentBox.BoxContainBall.ContainBall();
    }
}