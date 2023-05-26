﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoxSetPosition : CircleHolderAbstract
{
    [SerializeField] protected Direction direction;

    protected override void ResetValue()
    {
        base.ResetValue();
        direction = Direction.Up;
    }

    public void SetPosition(BoxController lastBoxController, float spacing)
    {
        direction = GetDirection(lastBoxController);
        var lastCirclePosition = lastBoxController.transform.position;
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

    protected virtual Direction GetDirection(BoxController lastBoxController)
    {
        var directions = new List<Direction>();
        switch (lastBoxController.BoxSetPosition.direction)
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