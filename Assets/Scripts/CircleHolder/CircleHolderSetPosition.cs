using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CircleHolderSetPosition : CircleHolderAbstract
{
    [SerializeField] protected Direction direction;

    protected override void ResetValue()
    {
        base.ResetValue();
        direction = Direction.Up;
    }

    public void SetPosition(CircleHolderController lastCircleHolderController, float spacing)
    {
        direction = GetDirection(lastCircleHolderController);
        var lastCirclePosition = lastCircleHolderController.transform.position;
        Vector3 bonusPos;
        switch (direction)
        {
            case Direction.Up:
                bonusPos = new Vector3(0, spacing, 0);
                break;
            case Direction.Down:
                bonusPos = new Vector3(0, -spacing, 0);
                break;
            case Direction.Left:
                bonusPos = new Vector3(-spacing, 0, 0);
                break;
            case Direction.Right:
                bonusPos = new Vector3(spacing, 0, 0);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        transform.parent.transform.position = lastCirclePosition + bonusPos;
    }

    protected virtual Direction GetDirection(CircleHolderController lastCircleHolderController)
    {
        var directions = new List<Direction>();
        switch (lastCircleHolderController.CircleHolderSetPosition.direction)
        {
            case Direction.Up:
                directions.Add(Direction.Up);
                directions.Add(Direction.Left);
                directions.Add(Direction.Right);
                break;
            case Direction.Left:
                directions.Add(Direction.Left);
                directions.Add(Direction.Up);
                break;
            case Direction.Right:
                directions.Add(Direction.Right);
                directions.Add(Direction.Up);
                break;
        }

        var index = Random.Range(0, directions.Count);
        direction = directions[index];
        return direction;
    }
}