using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoxController : TruongMonoBehaviour
{
    [SerializeField] protected TextMeshPro id;
    public TextMeshPro Id => id;
    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model => model;
    [SerializeField] protected BoxSetPosition boxSetPosition;
    public BoxSetPosition BoxSetPosition => boxSetPosition;
    [SerializeField] protected BoxSetId boxSetId;
    public BoxSetId BoxSetId => boxSetId;
    [SerializeField] protected BoxSetColorModel boxSetColorModel;
    public BoxSetColorModel BoxSetColorModel => boxSetColorModel;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadId();
        LoadBoxSetPosition();
        LoadBoxSetId();
        LoadBoxSetColorModel();
    }


    protected void LoadModel()
    {
        model = transform.Find(TruongConstants.MODEL).GetComponent<SpriteRenderer>();
    }

    protected void LoadId()
    {
        id = transform.Find("Id").GetComponent<TextMeshPro>();
    }

    protected void LoadBoxSetPosition()
    {
        boxSetPosition = transform.Find("BoxSetPosition").GetComponent<BoxSetPosition>();
    }

    protected void LoadBoxSetId()
    {
        boxSetId = transform.Find("BoxSetId").GetComponent<BoxSetId>();
    }

    protected void LoadBoxSetColorModel()
    {
        boxSetColorModel =
            transform.Find("BoxSetColorModel").GetComponent<BoxSetColorModel>();
    }
}