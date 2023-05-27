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

    protected override void Awake()
    {
        base.Awake();
        if (Instance != null) Debug.LogError($"Only one {name} is allowed to exist");
        Instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        ball1 = transform.Find("Ball1").GetComponent<Ball>();
        ball2 = transform.Find("Ball2").GetComponent<Ball>();
    }
}