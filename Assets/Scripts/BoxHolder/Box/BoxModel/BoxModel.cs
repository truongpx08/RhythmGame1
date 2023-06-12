using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxModel : TruongMonoBehaviour
{
    [SerializeField] protected BoxModelColor boxModelColor;
    public BoxModelColor BoxModelColor => boxModelColor;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    public SpriteRenderer SpriteRenderer => spriteRenderer;
    [SerializeField] protected BoxIcon boxIcon;
    public BoxIcon BoxIcon => boxIcon;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBoxSetColorModel();
        LoadSpriteRenderer();
        LoadBoxIcon();
    }


    private void LoadSpriteRenderer()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
    }

    protected void LoadBoxSetColorModel()
    {
        boxModelColor =
            transform.Find("BoxModelColor").GetComponent<BoxModelColor>();
    }

    private void LoadBoxIcon()
    {
        boxIcon = GetComponentInChildren<BoxIcon>();
    }
}