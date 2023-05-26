using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CircleHolderSetId : CircleHolderAbstract
{
    [Button]
    public void SetId(int id)
    {
        circleHolderController.Id.text = id.ToString();
    }
}