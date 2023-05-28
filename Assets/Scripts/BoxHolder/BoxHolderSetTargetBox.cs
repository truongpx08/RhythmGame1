using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class BoxHolderSetTargetBox : MonoBehaviour
{
    [SerializeField] protected Box targetBox;
    public Box TargetBox => targetBox;

    [Button]
    public void SetTargetBox(Box newBox)
    {
        targetBox = newBox;
        targetBox.BoxAllowContainBall.Allow();
    }

    [Button]
    public void SetTargetBox()
    {
        BoxHolder.Instance.BoxHolderSetCurrentBox.SetCurrentBox(targetBox);
        var nextBox = GetNextBox();

        SetTargetBox(nextBox);
    }

    private Box GetNextBox()
    {
        var nextBox = TryGetNextBox();
        if (nextBox == null)
        {
            BoxSpawner.Instance.SpawnBoxes();
            nextBox = TryGetNextBox();
        }

        return nextBox;
    }

    private Box TryGetNextBox()
    {
        return BoxSpawner.Instance.Boxes.Find(b =>
            int.Parse(b.Id.text) ==
            int.Parse(targetBox.Id.text) + 1);
    }
}