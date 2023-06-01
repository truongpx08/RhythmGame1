using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class BoxId : BoxAbstract
{
    [SerializeField] protected int id;
    public int Id => id;
    [SerializeField] protected TextMeshPro idText;
    public TextMeshPro IdText => idText;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadId();
    }

    protected void LoadId()
    {
        idText = transform.Find("IdText").GetComponent<TextMeshPro>();
    }

    [Button]
    public void SetId(int value)
    {
        id = value;
        idText.text = value.ToString();
    }
}