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

        CheckDuplicatePrefab();

        if (Application.isPlaying)
        {
            Debug.LogWarning("Since prefabs is empty, you need to reset it at inspector for initialization.");
        }
    }

    protected void CheckDuplicatePrefab()
    {
        var duplicates = prefabs.GroupBy(x => x.name)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key);

        foreach (var prefabName in duplicates)
        {
            prefabs.Remove(prefabs.Find(p => p.name == prefabName));
            Debug.LogError($"Only one {prefabName} is allowed in prefabs, Has remove a {prefabName}");
        }
    }

    [Button]
    private void HidePrefab()
    {
        prefabs.ForEach(p => p.gameObject.SetActive(false));
    }

    [Button]
    private void ShowPrefab()
    {
        prefabs.ForEach(p => p.gameObject.SetActive(true));
    }

    protected Transform Spawn(string prefabName)
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

    protected Transform Spawn()
    {
        var prefab = GetRandomPrefab();
        if (prefab == null)
        {
            Debug.LogError($"No prefab found");
            return null;
        }

        var newPrefab = GetObjectFromPool(prefab);
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


    protected Transform GetObjectFromPool(Transform prefab)
    {
        foreach (var obj in objectsPool.Where(obj => obj.name == prefab.name))
        {
            objectsPool.Remove(obj);
            return obj;
        }

        return InstantiateObject(prefab);
    }


    protected Transform InstantiateObject(Transform obj)
    {
        Transform newPrefab = Instantiate(obj);
        newPrefab.name = obj.name;
        return newPrefab;
    }

    protected Transform GetPrefabByName(string prefabName)
    {
        return prefabs.Find(p => p.name == prefabName);
    }

    protected Transform GetRandomPrefab()
    {
        int index = Random.Range(0, prefabs.Count);
        return prefabs[index];
    }
}