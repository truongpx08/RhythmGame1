using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BoxModelColor : BoxModelAbstract
{
    [Button]
    public void SetColor(Color color)
    {
        boxModel.SpriteRenderer.color = color;
    }
}