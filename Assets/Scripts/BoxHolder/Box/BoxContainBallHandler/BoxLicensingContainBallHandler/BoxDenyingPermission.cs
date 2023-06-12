using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class BoxDenyingPermission : BoxAbstract
{
    [SerializeField] private bool canStartCalculation;
    [SerializeField] private bool isUnlockBoxCompleted;

    protected override void SetDefaultValue()
    {
        base.SetDefaultValue();
        canStartCalculation = false;
        isUnlockBoxCompleted = false;
    }

    private void Update()
    {
        CalculatorMissing();
    }

    protected void CalculatorMissing()
    {
        if (!box.BoxContainBallHandler.BoxLicensingContainBallHandler.BoxGrantingPermission.IsGranting ||
            box.BoxContainBallHandler.BoxContainedBallHandler.IsContained ||
            box.BoxId.Id == 1) return;
        if (!canStartCalculation)
        {
            if (CanPassABox(TwoBall.Instance.GetBallRotating(), BoxHolder.Instance.BoxHolderTargetBox.TargetBox))
            {
                canStartCalculation = true;
            }

            return;
        }

        if (!IsMissABox(TwoBall.Instance.GetBallRotating(), BoxHolder.Instance.BoxHolderTargetBox.TargetBox))
            return;
        if (isUnlockBoxCompleted)
        {
            isUnlockBoxCompleted = false;
            canStartCalculation = false;
            return;
        }

        Denying();
    }


    [Button]
    public void Denying()
    {
        box.BoxContainBallHandler.BoxLicensingContainBallHandler.BoxGrantingPermission.Denying();
    }

    [Button]
    public void SetIsFinishUnlockBox(bool value)
    {
        isUnlockBoxCompleted = value;
    }
}