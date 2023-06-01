using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxContainBallHandler : TruongMonoBehaviour
{
    [SerializeField] protected BoxLicensingContainBallHandler boxLicensingContainBallHandler;
    public BoxLicensingContainBallHandler BoxLicensingContainBallHandler => boxLicensingContainBallHandler;
    [SerializeField] protected BoxContainedBallHandler boxContainedBallHandler;
    public BoxContainedBallHandler BoxContainedBallHandler => boxContainedBallHandler;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBoxLicensingContainBallHandler();
        LoadBoxContainBallHandler();
    }

    private void LoadBoxLicensingContainBallHandler()
    {
        boxLicensingContainBallHandler = GetComponentInChildren<BoxLicensingContainBallHandler>();
    }

    private void LoadBoxContainBallHandler()
    {
        boxContainedBallHandler = GetComponentInChildren<BoxContainedBallHandler>();
    }
}