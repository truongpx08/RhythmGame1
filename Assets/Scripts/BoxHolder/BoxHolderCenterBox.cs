using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class BoxHolderCenterBox : TruongMonoBehaviour
{
    [SerializeField] protected Box centerBox;
    public Box CenterBox => centerBox;
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
    public void SetCenterBox(Box newBox)
    {
        boxHolderOldBox.RemoveOldBox(centerBox);

        centerBox = newBox;
        CameraController.Instance.Follow(centerBox.transform);
        centerBox.BoxModel.BoxModelColor.SetColor(Color.green);
        centerBox.BoxModel.BoxIcon.HideIcon();
        centerBox.BoxContainBallHandler.BoxContainedBallHandler.ContainBall();
    }
}