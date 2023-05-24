using System.Collections.Generic;
using UnityEngine;

public abstract class TruongMonoBehaviour : MonoBehaviour
{
    private void Reset()
    {
        LoadComponents();
        ResetValue();
    }

    protected virtual void LoadComponents()
    {
        //For overriding
    }

    protected virtual void ResetValue()
    {
        //For overriding
    }
}