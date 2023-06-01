using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLicensingContainBallHandler : BoxContainBallHandlerAbstract
{
    [SerializeField] protected BoxGrantingPermission boxGrantingPermission;
    public BoxGrantingPermission BoxGrantingPermission => boxGrantingPermission;
    [SerializeField] protected BoxDenyingPermission boxDenyingPermission;
    public BoxDenyingPermission BoxDenyingPermission => boxDenyingPermission;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBoxGrantingPermission();
        LoadBoxDenyingPermission();
    }


    private void LoadBoxGrantingPermission()
    {
        boxGrantingPermission = GetComponentInChildren<BoxGrantingPermission>();
    }

    private void LoadBoxDenyingPermission()
    {
        boxDenyingPermission = GetComponentInChildren<BoxDenyingPermission>();
    }
}