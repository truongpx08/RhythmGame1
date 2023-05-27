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
        var lastBox = boxes.Count == 0 ? null : boxes[boxes.Count - 1];
        for (var i = 0; i < amount; i++)
        {
            var newBox = SpawnRandomPrefab()
                .GetComponent<Box>();
            switch (count)
            {
                case 0:
                    InitStartBox();
                    BoxHolder.Instance.BoxHolderSetCurrentBox.SetCurrentBox(newBox);
                    break;
                case 1:
                    InitFollowLastBox();
                    BoxHolder.Instance.BoxHolderSetTargetBox.SetTargetBox(newBox);
                    break;
                default:
                    InitFollowLastBox();
                    break;
            }

            lastBox = newBox;
            boxes.Add(newBox);
            count++;

            void InitBox()
            {
                newBox.BoxSetId.SetId(count);
                // newBox.BoxSetColorModel.SetColor(Color.white);
            }

            void InitStartBox()
            {
                InitBox();
                newBox.BoxSetPosition.SetPosition(Vector3.zero);
            }

            void InitFollowLastBox()
            {
                InitBox();
                newBox.BoxSetPosition.SetPosition(lastBox, spacing);
            }
        }
    }
}