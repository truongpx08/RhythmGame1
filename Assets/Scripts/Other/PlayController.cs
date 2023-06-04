using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayController : TruongMonoBehaviour
{
    public static PlayController Instance { get; private set; }
    public GameConfig Config => config;
    [SerializeField] protected GameConfig config;
    public bool isPlaying;
    private new Camera camera;
    public bool isCompleted;

    protected override void Awake()
    {
        base.Awake();
        if (Instance != null) Debug.LogError($"Only one {name} is allowed to exist");
        Instance = this;
    }

    private void SetConfig()
    {
        config = new GameConfig
        {
            maxSpeed = 5, minSpeed = 4, distanceLimit = 0.1f, requiteDistance = 0.1f, hoopSpacing = 0.4f,
            hoopAmount = 10, isIncreaseSpeed = false
        };
    }


    [Button]
    public void OnPlay()
    {
        // isPlaying = true;
        // Player.Instance.OnPlay();
        // HolderSpawner.Instance.OnPlay();
    }

    [Button]
    public void OnEndGame()
    {
        isPlaying = false;
        CanvasController.Instance.losePanel.SetActive(true);
    }

    protected override void SetDefaultValue()
    {
        SetConfig();
    }
}

[Serializable]
public class GameConfig
{
    public float maxSpeed, minSpeed;

    [FormerlySerializedAs("requiteSpacing")]
    public float distanceLimit;

    public float requiteDistance, hoopSpacing;
    public int hoopAmount;
    public bool isIncreaseSpeed;
}