using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Box : TruongMonoBehaviour
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
    [SerializeField] protected BoxAllowContainBall boxAllowContainBall;
    public BoxAllowContainBall BoxAllowContainBall => boxAllowContainBall;
    [SerializeField] protected BoxContainBall boxContainBall;
    public BoxContainBall BoxContainBall => boxContainBall;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadId();
        LoadBoxSetPosition();
        LoadBoxSetId();
        LoadBoxSetColorModel();
        LoadBoxAllowContainBall();
        LoadBoxContainBall();
    }

    private void LoadBoxContainBall()
    {
        boxContainBall = transform.Find("BoxContainBall").GetComponent<BoxContainBall>();
    }


    protected void LoadModel()
    {
        model = transform.Find(Constants.MODEL).GetComponent<SpriteRenderer>();
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

    protected void LoadBoxAllowContainBall()
    {
        boxAllowContainBall =
            transform.Find("BoxAllowContainBall").GetComponent<BoxAllowContainBall>();
    }
}