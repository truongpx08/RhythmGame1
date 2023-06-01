using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class BoxHolderCurrentBox : TruongMonoBehaviour
{
    [SerializeField] protected Box currentBox;
    public Box CurrentBox => currentBox;
    [SerializeField] protected BoxHolderOldBox boxHolderOldBox;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBoxHolderOldBox();
    }

    private void LoadBoxHolderOldBox()
    {
        boxHolderOldBox = GetComponentInChildren<BoxHolderOldBox>();
    }

    [Button]
    public void SetCurrentBox(Box newBox)
    {
        boxHolderOldBox.RemoveOldBox(currentBox);

        currentBox = newBox;
        CameraController.Instance.Follow(currentBox.transform);
        currentBox.BoxModel.BoxModelColor.SetColor(Color.green);
        currentBox.BoxContainBallHandler.BoxContainedBallHandler.ContainBall();
    }
}