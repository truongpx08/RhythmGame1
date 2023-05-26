using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class CircleHolderController : TruongMonoBehaviour
{
    [SerializeField] protected TextMeshPro id;
    public TextMeshPro Id => id;
    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model => model;
    [SerializeField] protected CircleHolderSetPosition circleHolderSetPosition;
    public CircleHolderSetPosition CircleHolderSetPosition => circleHolderSetPosition;
    [SerializeField] protected CircleHolderSetId circleHolderSetId;
    public CircleHolderSetId CircleHolderSetId => circleHolderSetId;
    [SerializeField] protected CircleHolderSetColorModel circleHolderSetColorModel;
    public CircleHolderSetColorModel CircleHolderSetColorModel => circleHolderSetColorModel;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadId();
        LoadCircleHolderSetPosition();
        LoadCircleHolderSetId();
        LoadCircleHolderSetColorModel();
    }


    protected void LoadModel()
    {
        model = transform.Find(TruongConstants.MODEL).GetComponent<SpriteRenderer>();
    }

    protected void LoadId()
    {
        id = transform.Find("Id").GetComponent<TextMeshPro>();
    }

    protected void LoadCircleHolderSetPosition()
    {
        circleHolderSetPosition = transform.Find("CircleHolderSetPosition").GetComponent<CircleHolderSetPosition>();
    }

    protected void LoadCircleHolderSetId()
    {
        circleHolderSetId = transform.Find("CircleHolderSetId").GetComponent<CircleHolderSetId>();
    }

    protected void LoadCircleHolderSetColorModel()
    {
        circleHolderSetColorModel =
            transform.Find("CircleHolderSetColorModel").GetComponent<CircleHolderSetColorModel>();
    }
}