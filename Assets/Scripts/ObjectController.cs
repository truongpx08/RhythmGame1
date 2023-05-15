using System;
using System.Collections;
using System.Collections.Generic;
using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;

public class ObjectController : Singleton<ObjectController>
{
    public Transform centerPoint, objectPoint; // đối tượng Empty đại diện cho tâm đường tròn
    public float radius;
    public float speed, minSpeed, maxSpeed;
    [SerializeField] private float angle; // góc quay hiện tại
    [SerializeField] private float requireDistance; // góc quay hiện tại
    [SerializeField] public bool stop;
    Vector3 lastObjectPosition;

    private void Start()
    {
        angle = -Mathf.PI / 2;
        stop = true;
    }

    public void Init(GameConfig config)
    {
        radius = config.hoopSpacing;
        speed = minSpeed = config.minSpeed;
        maxSpeed = config.maxSpeed;
        requireDistance = config.requiteDistance;
        requiteSpacing = config.requiteSpacing;
        isIncreaseSpeed = config.isIncreaseSpeed;
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

    public float requiteSpacing;
    [SerializeField] private bool isIncreaseSpeed;

    [Button]
    public void OnTouch()
    {
        var currentHoopPosition = HoopController.Instance.currentHoop.transform.position;
        var distance = Vector3.Distance(objectPoint.position, currentHoopPosition);
        // Debug.Log($"{dis}");

        var isMiss = distance > requireDistance;
        if (isMiss)
        {
            CanvasController.Instance.losePanel.SetActive(true);
            stop = true;
            return;
        }

        OnPerfect();

        void OnPerfect()
        {
            objectPoint.position = currentHoopPosition;
            var objectPointPosition = objectPoint.position;
            var centerPointPosition = centerPoint.position;
            var deltaX = centerPointPosition.x - objectPointPosition.x;
            var deltaY = centerPointPosition.y - objectPointPosition.y;
            // Debug.Log($"{deltaX} {deltaY}");
            if (deltaY < -requiteSpacing)
                angle = -Mathf.PI / 2; //down
            else if (deltaY > requiteSpacing)
                angle = Mathf.PI / 2; //up
            else if (deltaX < -requiteSpacing)
                angle = Mathf.PI; //left
            else if (deltaX > requiteSpacing)
                angle = 0; //right
            (centerPoint, objectPoint) = (objectPoint, centerPoint);
            CameraController.Instance.Follow(centerPoint);
            lastObjectPosition = objectPoint.position;
            HoopController.Instance.UpdateCurHoop();

            if (speed < maxSpeed && isIncreaseSpeed)
            {
                speed += speed / 100f * 10;
            }
        }
    }
}