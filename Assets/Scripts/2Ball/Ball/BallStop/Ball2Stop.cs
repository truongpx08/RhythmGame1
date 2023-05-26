using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Ball2Stop : BallStop
{
    protected override void ResetValue()
    {
        base.ResetValue();
        isPause = false;
    }
}