using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BallAutoRotateAroundCenterAbstract : TruongMonoBehaviour
{
    [SerializeField] protected BallAutoRotateAroundCenter ballAutoRotateAroundCenter;
    public BallAutoRotateAroundCenter BallAutoRotateAroundCenter => ballAutoRotateAroundCenter;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBallAutoRotateAroundCenter();
    }

    protected void LoadBallAutoRotateAroundCenter()
    {
        ballAutoRotateAroundCenter = transform.parent.GetComponent<BallAutoRotateAroundCenter>();
    }
}