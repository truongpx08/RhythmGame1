﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassABoxChecker : TruongMonoBehaviour
{
    [SerializeField] protected float distanceLimit;

    protected override void SetDefaultValue()
    {
        base.SetDefaultValue();
        distanceLimit = 0.05f;
    }

    public bool IsPassABox(Ball ballRotating, Box targetBox)
    {
        return CanPassABox(ballRotating, targetBox) &&
               BoxHolder.Instance.BoxHolderTargetBox.TargetBox.BoxContainBallHandler.BoxLicensingContainBallHandler
                   .BoxGrantingPermission.IsGranting;
    }

    public bool IsMissABox(Ball ballRotating, Box targetBox)
    {
        return !CanPassABox(ballRotating, targetBox);
    }

    public bool CanPassABox(Ball ballRotating, Box targetBox)
    {
        return Vector3.Distance(ballRotating.transform.position, targetBox.transform.position) <
               distanceLimit;
    }
}