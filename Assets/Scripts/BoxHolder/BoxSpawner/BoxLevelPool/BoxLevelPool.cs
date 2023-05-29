using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLevelPool : TruongMonoBehaviour
{
    [SerializeField] protected BoxAddBoxesToLevelPool boxAddBoxesToLevelPool;
    public BoxAddBoxesToLevelPool BoxAddBoxesToLevelPool => boxAddBoxesToLevelPool;
    [SerializeField] protected BoxSpawnObjFromLevelPool boxSpawnObjFromLevelPool;
    public BoxSpawnObjFromLevelPool BoxSpawnObjFromLevelPool => boxSpawnObjFromLevelPool;

    [SerializeField] protected List<string> boxLevelPool = new List<string>();
    public List<string> _BoxLevelPool => boxLevelPool;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBoxSpawnerAddBoxesToLevelPool();
        LoadBoxSpawnObjFromLevelPool();
    }


    private void LoadBoxSpawnerAddBoxesToLevelPool()
    {
        boxAddBoxesToLevelPool = transform.Find("BoxAddBoxesToLevelPool")
            .GetComponent<BoxAddBoxesToLevelPool>();
    }

    private void LoadBoxSpawnObjFromLevelPool()
    {
        boxSpawnObjFromLevelPool = transform.Find("BoxSpawnObjFromLevelPool").GetComponent<BoxSpawnObjFromLevelPool>();
    }
}