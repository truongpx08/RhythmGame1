using System;
using System.Collections.Generic;
using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;

public class CircleHolderSpawner : Spawner
{
    public static CircleHolderSpawner Instance { get; private set; }
    [SerializeField] private int amount;
    [SerializeField] private float spacing;

    private CircleHolder _currentCircleHolder;
    private List<CircleHolder> holders = new List<CircleHolder>();

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
        var isStart = _currentCircleHolder == null;
        CircleHolder lastHolder = null;
        lastHolder = holders.Count == 0 ? null : holders[holders.Count - 1];
        for (var i = 0; i < amount; i++)
        {
            var newHoop = Spawn("CircleHolder", new Vector3(0, 0.4f, 0), Quaternion.identity)
                .GetComponent<CircleHolder>();
            if (i == 0 && isStart)
                newHoop.Init(i);
            else
                newHoop.InitFollowLastHolder(lastHolder, i, spacing);

            if (i == 0)
                _currentCircleHolder = newHoop;
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