using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BoxSetColorModel : CircleHolderAbstract
{
    [Button]
    public void SetColor(Color color)
    {
        boxController.Model.color = color;
    }
}