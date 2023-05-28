using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BallGetAbilityFromBox : TwoBallAbstract
{
    [Button]
    public void GetAbilityFromBox(Box targetBox)
    {
        switch (targetBox.name)
        {
            case BoxName.NormalBox:
                break;
            case BoxName.ReverseBox:
                twoBall.TwoBallAbilities.TwoBallReverser.Effect();
                break;
            case BoxName.SpeedUpBox:
                twoBall.TwoBallAbilities.TwoBallSpeedUp.Effect();
                break;
            case BoxName.SpeedDownBox:
                twoBall.TwoBallAbilities.TwoBallSpeedDown.Effect();
                break;
        }
    }
}