using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoxPosition : BoxAbstract
{
    [Tooltip("Direction relative to the previous box")]
    [SerializeField] protected Direction direction;

    protected override void ResetValue()
    {
        base.ResetValue();
        direction = Direction.Up;
    }

    public void SetPosition(Vector3 position)
    {
        transform.parent.transform.position = position;
    }

    public void SetPosition(Box lastBox, float spacing)
    {
        direction = GetDirection(lastBox);
        var lastCirclePosition = lastBox.transform.position;
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

        SetPosition(lastCirclePosition + bonusPos);
    }

    protected virtual Direction GetDirection(Box lastBox)
    {
        var directions = new List<Direction>();
        switch (lastBox.BoxPosition.direction)
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