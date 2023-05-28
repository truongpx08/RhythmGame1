using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class TwoBall : TruongMonoBehaviour
{
    public static TwoBall Instance { get; private set; }
    [SerializeField] protected Ball ball1;
    public Ball Ball1 => ball1;
    [SerializeField] protected Ball ball2;
    public Ball Ball2 => ball2;
    [SerializeField] protected TwoBallReverser twoBallReverser;

    public TwoBallReverser TwoBallReverser => twoBallReverser;

    protected override void Awake()
    {
        base.Awake();
        if (Instance != null) Debug.LogError($"Only one {name} is allowed to exist");
        Instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBall1();
        LoadBall2();
        LoadBallReverser();
    }

    private void LoadBall1()
    {
        ball1 = transform.Find("Ball1").GetComponent<Ball>();
    }

    private void LoadBall2()
    {
        ball2 = transform.Find("Ball2").GetComponent<Ball>();
    }

    protected void LoadBallReverser()
    {
        twoBallReverser = transform.Find("TwoBallReverser").GetComponent<TwoBallReverser>();
    }

    [Button]
    public Ball GetBallCenter()
    {
        return ball1.BallAutoRotateAroundCenter.IsRotating ? ball2 : ball1;
    }

    [Button]
    public Ball GetBallRotating()
    {
        return ball1.BallAutoRotateAroundCenter.IsRotating ? ball1 : ball2;
    }
}