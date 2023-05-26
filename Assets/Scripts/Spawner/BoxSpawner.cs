using System;
using System.Collections.Generic;
using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;

public class BoxSpawner : Spawner
{
    public static BoxSpawner Instance { get; private set; }
    [SerializeField] private int amount;
    [SerializeField] private float spacing;

    private BoxController currentBox;
    private readonly List<BoxController> boxes = new List<BoxController>();

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
    }

    [Button]
    public void SpawnBoxes()
    {
        var isStart = currentBox == null;
        BoxController lastBox = null;
        lastBox = boxes.Count == 0 ? null : boxes[boxes.Count - 1];
        for (var i = 0; i < amount; i++)
        {
            var newBox = Spawn("Box", new Vector3(0, 0.4f, 0), Quaternion.identity)
                .GetComponent<BoxController>();
            if (i == 0 && isStart)
            {
                InitBox();
            }
            else
                InitFollowLastBox();

            if (i == 0)
                currentBox = newBox;
            lastBox = newBox;
            boxes.Add(newBox);

            void InitBox()
            {
                newBox.BoxSetId.SetId(i);
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