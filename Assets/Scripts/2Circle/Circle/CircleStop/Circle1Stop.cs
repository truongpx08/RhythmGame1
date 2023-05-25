using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Circle1Stop : CircleStop
{
    protected override void ResetValue()
    {
        base.ResetValue();
        isPause = true;
    }
}