﻿using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Circle2Stop : CircleStop
{
    protected override void ResetValue()
    {
        base.ResetValue();
        isPause = false;
    }
}