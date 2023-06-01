using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxModel : TruongMonoBehaviour
{
    [SerializeField] protected BoxModelColor boxModelColor;
    public BoxModelColor BoxModelColor => boxModelColor;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    public SpriteRenderer SpriteRenderer => spriteRenderer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBoxSetColorModel();
        LoadSpriteRenderer();
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
}