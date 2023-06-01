using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BoxHolder : TruongMonoBehaviour
{
    public static BoxHolder Instance { get; private set; }
    [SerializeField] protected BoxSpawner boxSpawner;
    public BoxSpawner BoxSpawner => boxSpawner;
    [SerializeField] protected BoxHolderTargetBox boxHolderTargetBox;
    public BoxHolderTargetBox BoxHolderTargetBox => boxHolderTargetBox;
    [SerializeField] protected BoxHolderCurrentBox boxHolderCurrentBox;
    public BoxHolderCurrentBox BoxHolderCurrentBox => boxHolderCurrentBox;
    [SerializeField] protected BoxHolderOldBox boxHolderOldBox;
    public BoxHolderOldBox BoxHolderOldBox => boxHolderOldBox;

    protected override void Awake()
    {
        base.Awake();
        if (Instance != null) Debug.LogError($"Only one {name} is allowed to exist");
        Instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBoxSetBoxCanContainBall();
        LoadBoxHolderSetCurrentBox();
        LoadBoxRemoveOldBox();
        LoadBoxSpawner();
    }

    protected void LoadBoxHolderSetCurrentBox()
    {
        boxHolderCurrentBox = GetComponentInChildren<BoxHolderCurrentBox>();
    }

    protected void LoadBoxSetBoxCanContainBall()
    {
        boxHolderTargetBox =
            GetComponentInChildren<BoxHolderTargetBox>();
    }

    private void LoadBoxRemoveOldBox()
    {
        boxHolderOldBox = GetComponentInChildren<BoxHolderOldBox>();
    }

    private void LoadBoxSpawner()
    {
        boxSpawner = GetComponentInChildren<BoxSpawner>();
    }
}