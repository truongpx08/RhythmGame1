using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

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
        //ToDo: Remove old box
        AddBoxesToLevelPool();
        var lastBox = boxes.Count == 0 ? null : boxes[boxes.Count - 1];
        for (var i = 0; i < amount; i++)
        {
            var newBox = SpawnObjFromLevelPool()
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

    [SerializeField] protected List<string> boxLevelPool = new List<string>();

    protected void AddBoxesToLevelPool()
    {
        boxLevelPool.Clear();
        for (int index = 0; index < 15; index++)
        {
            switch (index)
            {
                case 0:
                case 3:
                case 4:
                    AddBoxToPool(BoxName.ReverseBox);
                    break;
                case 1:
                    AddBoxToPool(BoxName.SpeedUpBox);
                    break;
                case 2:
                    AddBoxToPool(BoxName.SpeedDownBox);
                    break;
                default:
                    AddBoxToPool(BoxName.NormalBox);
                    break;
            }
        }
    }


    protected void AddBoxToPool(string boxName)
    {
        if (CanAddBox(boxName))
            boxLevelPool.Add(boxName);
    }

    protected bool CanAddBox(string targetBox)
    {
        var value = false;
        switch (targetBox)
        {
            case BoxName.NormalBox:
                value = true;
                break;
            case BoxName.ReverseBox:
                value = true;
                break;
            case BoxName.SpeedUpBox:
                value = TwoBall.Instance.TwoBallAbilities.TwoBallSpeedUp.Amount < 3;
                break;
            case BoxName.SpeedDownBox:
                value = TwoBall.Instance.TwoBallAbilities.TwoBallSpeedUp.Amount >
                        TwoBall.Instance.TwoBallAbilities.TwoBallSpeedDown.Amount &&
                        TwoBall.Instance.TwoBallAbilities.TwoBallSpeedDown.Amount < 3;
                break;
        }

        return value;
    }

    protected Transform SpawnObjFromLevelPool()
    {
        var prefabName = GetRandomPrefabNameInLevelPool();
        return Spawn(prefabName);
    }

    protected string GetRandomPrefabNameInLevelPool()
    {
        int index = UnityEngine.Random.Range(0, boxLevelPool.Count);
        string value = boxLevelPool[index];
        boxLevelPool.Remove(boxLevelPool[index]);
        return value;
    }
}