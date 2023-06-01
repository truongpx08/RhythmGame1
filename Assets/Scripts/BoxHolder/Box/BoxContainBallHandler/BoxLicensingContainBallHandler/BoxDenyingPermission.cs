using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class BoxDenyingPermission : BoxAbstract
{
    [SerializeField] private bool canStartCalculation;

    protected override void ResetValue()
    {
        base.ResetValue();
        canStartCalculation = false;
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
        Denying();
    }

    [Button]
    public void Denying()
    {
        box.BoxContainBallHandler.BoxLicensingContainBallHandler.BoxGrantingPermission.Denying();
    }
}