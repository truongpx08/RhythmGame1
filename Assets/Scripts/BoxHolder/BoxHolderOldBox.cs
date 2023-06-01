using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BoxHolderOldBox : MonoBehaviour
{
    [Button]
    public void RemoveOldBox(Box oldBox)
    {
        if (oldBox == null) return;
        oldBox.DespawnParent.DespawnObject();
        BoxSpawner.Instance.Boxes.Remove(oldBox);
    }
}