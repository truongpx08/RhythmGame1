using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BoxIcon : TruongMonoBehaviour
{
    [SerializeField] protected SpriteRenderer iconModel;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadIconModel();
    }

    private void LoadIconModel()
    {
        iconModel = transform.Find("IconModel").GetComponent<SpriteRenderer>();
    }

    [Button]
    public void ShowIcon()
    {
        iconModel.gameObject.SetActive(true);
    }

    [Button]
    public void HideIcon()
    {
        iconModel.gameObject.SetActive(false);
    }
}