using System;
using System.Collections.Generic;
using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class BoxSpawner : Spawner
{
    public static BoxSpawner Instance { get; private set; }
    [SerializeField] protected int amount;
    [SerializeField] protected float spacing;
    [SerializeField] protected int count;
    [SerializeField] protected List<Box> boxes = new List<Box>();
    public List<Box> Boxes => boxes;


    protected override void Awake()
    {
        base.Awake();
        if (Instance != null) Debug.LogError($"Only one {name} is allowed to exist");
        Instance = this;
    }

    private void Start()
    {
        SpawnBoxes();
    }

    protected override void ResetValue()
    {
        amount = 10;
        spacing = 0.4f;
        count = 0;
    }

    [Button]
    public void SpawnBoxes()
    {
        var isStart = count == 0;
        var lastBox = boxes.Count == 0 ? null : boxes[boxes.Count - 1];
        for (var i = 0; i < amount; i++)
        {
            var newBox = Spawn("Box", new Vector3(0, 0.4f, 0), Quaternion.identity)
                .GetComponent<Box>();
            if (i == 0 && isStart)
                InitBox();
            else
                InitFollowLastBox();

            if (i == 0)
            {
                BoxHolder.Instance.BoxSetBoxCanContainBall.SetBoxCanContainBall(newBox);
            }

            lastBox = newBox;
            boxes.Add(newBox);
            count++;

            void InitBox()
            {
                newBox.BoxSetId.SetId(count);
                newBox.BoxSetColorModel.SetColor(Color.white);
            }

            void InitFollowLastBox()
            {
                InitBox();
                newBox.BoxSetPosition.SetPosition(lastBox, spacing);
            }
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