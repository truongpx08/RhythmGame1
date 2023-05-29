using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawnObjFromLevelPool : BoxLevelPoolAbstract
{
    public Transform SpawnObjFromLevelPool()
    {
        var prefabName = GetRandomPrefabNameInLevelPool();
        return BoxSpawner.Instance.Spawn(prefabName);
    }

    protected string GetRandomPrefabNameInLevelPool()
    {
        int index = Random.Range(0, boxLevelPool._BoxLevelPool.Count);
        string value = boxLevelPool._BoxLevelPool[index];
        boxLevelPool._BoxLevelPool.Remove(boxLevelPool._BoxLevelPool[index]);
        return value;
    }
}