using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class TwoBallAbilities : TruongMonoBehaviour
{
    [SerializeField] protected TwoBallReverser twoBallReverser;
    public TwoBallReverser TwoBallReverser => twoBallReverser;

    [SerializeField] protected TwoBallSpeedUp twoBallSpeedUp;
    public TwoBallSpeedUp TwoBallSpeedUp => twoBallSpeedUp;
    [SerializeField] protected TwoBallSpeedDown twoBallSpeedDown;
    public TwoBallSpeedDown TwoBallSpeedDown => twoBallSpeedDown;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBallReverser();
        LoadTwoBallSpeedUp();
        LoadTwoBallSpeedDown();
    }

    private void LoadTwoBallSpeedDown()
    {
        twoBallSpeedDown = transform.Find("TwoBallSpeedDown").GetComponent<TwoBallSpeedDown>();
    }

    private void LoadTwoBallSpeedUp()
    {
        twoBallSpeedUp = transform.Find("TwoBallSpeedUp").GetComponent<TwoBallSpeedUp>();
    }

    protected void LoadBallReverser()
    {
        twoBallReverser = transform.Find("TwoBallReverser").GetComponent<TwoBallReverser>();
    }
}