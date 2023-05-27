using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Spawner : TruongMonoBehaviour
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
        holder = transform.Find(Constants.HOLDER);
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
        HidePrefab();
    }


    private void LoadPrefabs()
    {
        if (prefabs.Count > 0)
            return;

        var prefabsTransform = transform.Find(Constants.PREFABS);
        if (prefabsTransform == null)
        {
            Debug.LogError("No prefabs found");
            return;
        }

        foreach (Transform prefab in prefabsTransform)
        {
            prefabs.Add(prefab);
        }

        if (Application.isPlaying)
        {
            Debug.LogWarning("Since prefabs is empty, you need to reset it at inspector for initialization.");
        }
    }

    [Button]
    private void HidePrefab()
    {
        prefabs.ForEach(p => p.gameObject.SetActive(false));
    }

    protected Transform Spawn(string prefabName, Vector3 spawnPosition, Quaternion spawnRotation)
    {
        var prefab = GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogError($"No prefab {prefabName} found");
            return null;
        }

        var newPrefab = GetObjectFromPool(prefab);
        SetPrefab(newPrefab);
        return newPrefab;
    }

    protected Transform SpawnRandomPrefab()
    {
        var newPrefab = GetObjectFromPrefab();
        SetPrefab(newPrefab);
        return newPrefab;
    }

    protected void SetPrefab(Transform newPrefab)
    {
        // newPrefab.SetPositionAndRotation(spawnPosition, spawnRotation);
        newPrefab.parent = holder;
        newPrefab.gameObject.SetActive(true);
    }

    protected internal void Despawn(Transform obj)
    {
        obj.gameObject.SetActive(false);
        objectsPool.Add(obj);
    }


    private Transform GetObjectFromPool(Transform prefab)
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

    private Transform GetObjectFromPrefab()
    {
        int index = Random.Range(0, prefabs.Count);
        var obj = prefabs[index];
        return Instantiate(obj);
    }

    private Transform GetPrefabByName(string prefabName)
    {
        return prefabs.Find(p => p.name == prefabName);
    }
}