using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BoxHolder : TruongMonoBehaviour
{
    public static BoxHolder Instance { get; private set; }
    [SerializeField] protected BoxHolderSetTargetBox boxHolderSetTargetBox;
    public BoxHolderSetTargetBox BoxHolderSetTargetBox => boxHolderSetTargetBox;
    [SerializeField] protected BoxHolderSetCurrentBox boxHolderSetCurrentBox;
    public BoxHolderSetCurrentBox BoxHolderSetCurrentBox => boxHolderSetCurrentBox;
    [SerializeField] protected BoxRemoveOldBox boxRemoveOldBox;
    public BoxRemoveOldBox BoxRemoveOldBox => boxRemoveOldBox;

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
    }


    protected void LoadBoxHolderSetCurrentBox()
    {
        boxHolderSetCurrentBox = transform.Find("BoxHolderSetCurrentBox").GetComponent<BoxHolderSetCurrentBox>();
    }

    protected void LoadBoxSetBoxCanContainBall()
    {
        boxHolderSetTargetBox =
            transform.Find("BoxHolderSetTargetBox").GetComponent<BoxHolderSetTargetBox>();
    }

    private void LoadBoxRemoveOldBox()
    {
        boxRemoveOldBox = transform.Find("BoxRemoveOldBox").GetComponent<BoxRemoveOldBox>();
    }
}