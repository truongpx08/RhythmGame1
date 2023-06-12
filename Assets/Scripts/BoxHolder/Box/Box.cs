using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Box : TruongMonoBehaviour
{
    [SerializeField] protected BoxModel boxModel;
    public BoxModel BoxModel => boxModel;
    [SerializeField] protected BoxId boxId;
    public BoxId BoxId => boxId;
    [SerializeField] protected DespawnParent despawnParent;
    public DespawnParent DespawnParent => despawnParent;
    [SerializeField] protected BoxPosition boxPosition;
    public BoxPosition BoxPosition => boxPosition;
    [SerializeField] protected BoxContainBallHandler boxContainBallHandler;
    public BoxContainBallHandler BoxContainBallHandler => boxContainBallHandler;
    [SerializeField] protected BoxUnlockHandler boxUnlockHandler;
    public virtual BoxUnlockHandler BoxUnlockHandler => boxUnlockHandler;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadBoxId();
        LoadBoxPosition();
        LoadDespawnParent();
        LoadBoxContainBallHandler();
    }


    protected void LoadModel()
    {
        boxModel = transform.Find("BoxModel").GetComponent<BoxModel>();
    }

    protected void LoadBoxId()
    {
        boxId = transform.Find("BoxId").GetComponent<BoxId>();
    }

    private void LoadDespawnParent()
    {
        despawnParent = transform.Find("DespawnParent").GetComponent<DespawnParent>();
    }

    protected void LoadBoxPosition()
    {
        boxPosition = GetComponentInChildren<BoxPosition>();
    }

    private void LoadBoxContainBallHandler()
    {
        boxContainBallHandler = GetComponentInChildren<BoxContainBallHandler>();
    }
}