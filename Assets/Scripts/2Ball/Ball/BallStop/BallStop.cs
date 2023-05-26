using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BallStop : TruongMonoBehaviour
{
    [SerializeField] protected bool isPause;
    public bool IsPause => isPause;

    private void Update()
    {
        if (InputManager.Instance.IsKeyDown)
        {
            isPause = !isPause;
        }
    }

    [Button]
    protected void Pause()
    {
        isPause = true;
    }

    [Button]
    protected void Continue()
    {
        isPause = false;
    }
}