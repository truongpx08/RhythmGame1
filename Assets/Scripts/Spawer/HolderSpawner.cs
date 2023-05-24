using System;
using System.Collections.Generic;
using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;

public class HolderSpawner : Spawner
{
    public static HolderSpawner Instance { get; private set; }
    private List<Holder> holders = new List<Holder>();
    [SerializeField] private int amount;
    [SerializeField] private float spacing;
    private Holder currentHolder;

    protected override void Awake()
    {
        base.Awake();
        if (Instance != null) Debug.LogError($"Only one {name} is allowed to exist");
        Instance = this;
    }

    protected override void ResetValue()
    {
        amount = 10;
        spacing = 0.4f;
    }

    [Button]
    public void SpawnHolders()
    {
        var isStart = currentHolder == null;
        var lastHolder = currentHolder;
        for (var i = 0; i < amount; i++)
        {
            var newHoop = Spawn("Holder", Vector3.zero, Quaternion.identity).GetComponent<Holder>();
            if (i == 0 && isStart)
                newHoop.Init(i);
            else
                newHoop.InitFollowLastHolder(lastHolder, i, spacing);

            if (i == 0)
                currentHolder = newHoop;
            lastHolder = newHoop;
            holders.Add(newHoop);
        }
    }

    // public void OnPlay()
    // {
    //     RemoveHolders();
    //     currentHolder = null;
    //     SpawnHolders();
    // }
    //
    // [Button]
    // private void RemoveHolders()
    // {
    //     holders.ForEach(h => Destroy(h.gameObject));
    //     holders.Clear();
    // }


    // public void UpdateCurrentHolder()
    // {
    //     currentHolder.Complete();
    //     var nextHolderIndex = holders.IndexOf(currentHolder) + 1;
    //     var isLastHolderInPool = nextHolderIndex == holders.Count;
    //     if (isLastHolderInPool)
    //     {
    //         SpawnHolders();
    //     }
    //     else
    //     {
    //         currentHolder = holders[nextHolderIndex];
    //         Debug.Log($"currentHoop = {currentHolder.name}");
    //     }
    // }

    // public Holder GetCurrentHolder()
    // {
    //     return currentHolder;
    // }
}