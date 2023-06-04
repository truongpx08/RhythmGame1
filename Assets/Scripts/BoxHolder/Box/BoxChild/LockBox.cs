using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBox : Box
{
    public override BoxUnlockHandler BoxUnlockHandler => boxUnlockHandler;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBoxUnlockHandler();
    }

    private void LoadBoxUnlockHandler()
    {
        boxUnlockHandler = GetComponentInChildren<BoxUnlockHandler>();
    }
}