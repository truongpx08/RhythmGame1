using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;

public class Player : Singleton<Player>
{
    public Transform centerPoint, objectPoint;
    private float angle;
    private bool isIncreaseSpeed;
    private float maxSpeed;
    private float minSpeed;
    private float radius;
    private float requireDistance;
    private float requiteSpacing;
    private float speed;
    private bool stop;

    private void Start()
    {
        GetConfig();
    }

    private void Update()
    {
        if (!stop)
        {
            angle -= speed * Time.deltaTime; // cập nhật góc quay
            var position = centerPoint.position;
            var x = position.x + radius * Mathf.Cos(angle);
            var y = position.y + radius * Mathf.Sin(angle);

            objectPoint.transform.position = new Vector3(x, y, transform.position.z);
        }
    }

    protected void GetConfig()
    {
        var config = PlayController.Instance.Config;
        radius = config.hoopSpacing;
        speed = minSpeed = config.minSpeed;
        maxSpeed = config.maxSpeed;
        requireDistance = config.requiteDistance;
        requiteSpacing = config.requiteSpacing;
        isIncreaseSpeed = config.isIncreaseSpeed;

        angle = -Mathf.PI / 2;
        stop = true;
    }

    public void OnPlay()
    {
        stop = false;
        centerPoint.position = Vector3.zero;
        angle = -Mathf.PI / 2;
        speed = minSpeed;
        CameraController.Instance.Follow(centerPoint);
    }

    [Button]
    public void SwitchActive()
    {
        stop = !stop;
    }

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
    // HolderSpawner.Instance.UpdateCurrentHolder();
    //
    //         if (speed < maxSpeed && isIncreaseSpeed) speed += speed / 100f * 10;
    //     }
    // }
}