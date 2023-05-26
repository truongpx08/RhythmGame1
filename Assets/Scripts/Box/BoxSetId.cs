using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BoxSetId : CircleHolderAbstract
{
    [Button]
    public void SetId(int id)
    {
        boxController.Id.text = id.ToString();
    }
}