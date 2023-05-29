using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BoxRemoveOldBox : MonoBehaviour
{
    [Button]
    public void RemoveOldBox(Box oldBox)
    {
        oldBox.DespawnParent.DespawnObject();
        BoxSpawner.Instance.Boxes.Remove(oldBox);
    }
}