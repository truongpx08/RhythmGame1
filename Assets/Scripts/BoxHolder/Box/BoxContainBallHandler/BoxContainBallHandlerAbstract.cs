using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxContainBallHandlerAbstract : TruongMonoBehaviour
{
    [SerializeField] protected BoxContainBallHandler boxContainBallHandler;
    public BoxContainBallHandler BoxContainBallHandler => boxContainBallHandler;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBoxContainBallHandler();
    }

    private void LoadBoxContainBallHandler()
    {
        boxContainBallHandler = GetParentComponent<BoxContainBallHandler>();
    }
}