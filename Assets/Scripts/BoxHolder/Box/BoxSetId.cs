using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BoxSetId : BoxAbstract
{
    [Button]
    public void SetId(int id)
    {
        box.Id.text = id.ToString();
    }
}