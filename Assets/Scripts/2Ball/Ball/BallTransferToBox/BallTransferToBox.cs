using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class BallTransferToBox : BallAbstract
{
    public void TransferToBox(Box boxTarget)
    {
        transform.parent.transform.position = boxTarget.transform.position;
    }
}