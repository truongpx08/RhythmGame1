using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CircleHolderSetColorModel : CircleHolderAbstract
{
    [Button]
    public void SetColor(Color color)
    {
        circleHolderController.Model.color = color;
    }
}