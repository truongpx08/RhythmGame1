using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BoxSpawner : Spawner
{
    public static BoxSpawner Instance { get; private set; }
    [SerializeField] protected BoxLevelPool boxLevelPool;
    public BoxLevelPool BoxLevelPool => boxLevelPool;
    [SerializeField] protected int amount;
    [SerializeField] protected float spacing;
    [SerializeField] protected int count;
    [SerializeField] protected List<Box> boxes = new List<Box>();
    public List<Box> Boxes => boxes;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBoxLevelPool();
    }

    private void LoadBoxLevelPool()
    {
        boxLevelPool = transform.Find("BoxLevelPool").GetComponent<BoxLevelPool>();
    }

    protected override void SetDefaultValue()
    {
        amount = 10;
        spacing = 0.4f;
        count = 0;
    }

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

    [Button]
    public void SpawnBoxes()
    {
        boxLevelPool.BoxAddBoxesToLevelPool.AddBoxesToLevelPool();
        var lastBox = boxes.Count == 0 ? null : boxes[boxes.Count - 1];
        for (var i = 0; i < amount; i++)
        {
            var newBox = boxLevelPool.BoxSpawnObjFromLevelPool.SpawnObjFromLevelPool()
                .GetComponent<Box>();
            switch (count)
            {
                case 0:
                    InitStartBox(newBox);
                    BoxHolder.Instance.BoxHolderCurrentBox.SetCurrentBox(newBox);
                    break;
                case 1:
                    InitFollowLastBox(newBox, lastBox);
                    BoxHolder.Instance.BoxHolderTargetBox.SetTargetBox(newBox);
                    break;
                default:
                    InitFollowLastBox(newBox, lastBox);
                    break;
            }

            lastBox = newBox;
            boxes.Add(newBox);
            count++;
        }
    }

    protected void InitBox(Box newBox)
    {
        newBox.BoxId.SetId(count);
        newBox.BoxModel.BoxModelColor.SetColor(GetColorWithBoxName(newBox.name));
    }

    Color GetColorWithBoxName(string boxName)
    {
        switch (boxName)
        {
            case BoxName.NormalBox:
                return Color.white;
            case BoxName.ReverseBox:
                return Color.yellow;
            case BoxName.SpeedUpBox:
                return Color.blue;
            case BoxName.SpeedDownBox:
                return Color.magenta;
            case BoxName.LockBox:
                return Color.grey;
        }

        return default;
    }

    protected void InitStartBox(Box newBox)
    {
        InitBox(newBox);
        newBox.BoxPosition.SetPosition(Vector3.zero);
    }

    protected void InitFollowLastBox(Box newBox, Box lastBox)
    {
        InitBox(newBox);
        newBox.BoxPosition.SetPosition(lastBox, spacing);
    }
}