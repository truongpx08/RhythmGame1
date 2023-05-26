using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class TwoBallController : TruongMonoBehaviour
{
    public static TwoBallController Instance { get; private set; }
    [SerializeField] protected BallController ball1;
    public BallController Ball1 => ball1;
    [SerializeField] protected BallController ball2;
    public BallController Ball2 => ball2;

    protected override void Awake()
    {
        base.Awake();
        if (Instance != null) Debug.LogError($"Only one {name} is allowed to exist");
        Instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        ball1 = transform.Find("Ball1").GetComponent<BallController>();
        ball2 = transform.Find("Ball2").GetComponent<BallController>();
    }

    // protected override void ResetValue()
    // {
    //     base.ResetValue();
    //     var config = new GameConfig
    //     {
    //         maxSpeed = 5, minSpeed = 4, requiteSpacing = 0.1f, requiteDistance = 0.1f, hoopSpacing = 0.4f,
    //         hoopAmount = 10, isIncreaseSpeed = false
    //     };
    //     radius = config.hoopSpacing;
    //     speed = minSpeed = config.minSpeed;
    //     maxSpeed = config.maxSpeed;
    //     requireDistance = config.requiteDistance;
    //     requiteSpacing = config.requiteSpacing;
    //     isIncreaseSpeed = config.isIncreaseSpeed;
    //
    //     angle = -Mathf.PI / 2;
    //     stop = true;
    // }


    // public void OnPlay()
    // {
    //     stop = false;
    //     centerPoint.position = Vector3.zero;
    //     angle = -Mathf.PI / 2;
    //     speed = minSpeed;
    //     CameraController.Instance.Follow(centerPoint);
    // }

    // [Button]
    // public void SwitchActive()
    // {
    //     stop = !stop;
    // }

    // [Button]
    // public void OnTouch()
    // {
    //     var currentHoopPosition = HolderSpawner.Instance.GetCurrentHolder().transform.position;
    //     var distance = Vector3.Distance(objectPoint.position, currentHoopPosition);
    //     // Debug.Log($"{dis}");
    //
    //     var isMiss = distance > requireDistance;
    //     if (isMiss)
    //     {
    //         stop = true;
    //         PlayController.Instance.OnEndGame();
    //         return;
    //     }
    //
    //     OnPerfect();
    //
    //     void OnPerfect()
    //     {
    //         objectPoint.position = currentHoopPosition;
    //         var objectPointPosition = objectPoint.position;
    //         var centerPointPosition = centerPoint.position;
    //         var deltaX = centerPointPosition.x - objectPointPosition.x;
    //         var deltaY = centerPointPosition.y - objectPointPosition.y;
    //         // Debug.Log($"{deltaX} {deltaY}");
    //         if (deltaY < -requiteSpacing)
    //             angle = -Mathf.PI / 2; //down
    //         else if (deltaY > requiteSpacing)
    //             angle = Mathf.PI / 2; //up
    //         else if (deltaX < -requiteSpacing)
    //             angle = Mathf.PI; //left
    //         else if (deltaX > requiteSpacing)
    //             angle = 0; //right
    //         (centerPoint, objectPoint) = (objectPoint, centerPoint);
    //         CameraController.Instance.Follow(centerPoint);
    //         HolderSpawner.Instance.UpdateCurrentHolder();
    //
    //         if (speed < maxSpeed && isIncreaseSpeed) speed += speed / 100f * 10;
    //     }
    // }
}