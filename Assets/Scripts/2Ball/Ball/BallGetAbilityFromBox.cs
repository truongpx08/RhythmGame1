using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BallGetAbilityFromBox : TwoBallAbstract
{
    [Button]
    public void GetAbilityFromBox(Box targetBox)
    {
        if (targetBox.name == BoxName.NormalBox)
        {
        }
        else if (targetBox.name == BoxName.ReverseBox)
        {
            twoBall.TwoBallReverser.Reverse();
        }
    }
}