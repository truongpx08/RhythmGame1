using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BoxHolder : TruongMonoBehaviour
{
    public static BoxHolder Instance { get; private set; }
    [SerializeField] protected BoxSetBoxCanContainBall boxSetBoxCanContainBall;
    public BoxSetBoxCanContainBall BoxSetBoxCanContainBall => boxSetBoxCanContainBall;


    protected override void Awake()
    {
        base.Awake();
        if (Instance != null) Debug.LogError($"Only one {name} is allowed to exist");
        Instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBoxSetBoxCanContainBall();
    }

    protected void LoadBoxSetBoxCanContainBall()
    {
        boxSetBoxCanContainBall = transform.Find("BoxSetBoxCanContainBall").GetComponent<BoxSetBoxCanContainBall>();
    }
}