using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Ball1Stop : BallStop
{
    protected override void ResetValue()
    {
        base.ResetValue();
        isPause = true;
    }
}