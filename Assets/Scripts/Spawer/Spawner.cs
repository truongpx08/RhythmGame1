using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : TruongMonoBehaviour
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabs = new List<Transform>();
    [SerializeField] protected List<Transform> objectsPool = new List<Transform>();

    protected override void LoadComponents()
    {
        LoadPrefabs();
        LoadHolder();
    }

    private void LoadHolder()
    {
        if (holder != null) return;
        holder = transform.Find(TruongConstants.HOLDER);
    }


    private void LoadPrefabs()
    {
        if (prefabs.Count > 0) return;

        var prefabsTransform = transform.Find(TruongConstants.PREFABS);
        if (prefabsTransform == null)
        {
            Debug.LogError("No prefabs found");
            return;
        }

        foreach (Transform prefab in prefabsTransform)
        {
            prefabs.Add(prefab);
        }
    }


    protected Transform Spawn(string prefabName, Vector3 spawnPosition, Quaternion spawnRotation)
    {
        var prefab = GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogError("No prefab found");
            return null;
        }

        var newPrefab = GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPosition, spawnRotation);
        newPrefab.parent = holder;
        return newPrefab;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (var obj in objectsPool.Where(obj => obj.name == prefab.name))
        {
            objectsPool.Remove(obj);
            return obj;
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    protected Transform GetPrefabByName(string prefabName)
    {
        return prefabs.Find(p => p.name == prefabName);
    }
}