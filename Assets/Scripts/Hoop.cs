using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Hoop : MonoBehaviour
{
    public HoopDirection direction;
    public TextMeshPro idText;
    public SpriteRenderer spriteRenderer;

    public void Init(Hoop lastHoop, int id)
    {
        idText.text = id.ToString();
        spriteRenderer.color = Color.yellow;
        var spacing = HoopController.Instance.spacing;
        var directions = new List<HoopDirection>();
        switch (lastHoop.direction)
        {
            case HoopDirection.Up:
                directions.Add(HoopDirection.Up);
                directions.Add(HoopDirection.Left);
                directions.Add(HoopDirection.Right);
                break;
            case HoopDirection.Left:
                directions.Add(HoopDirection.Left);
                directions.Add(HoopDirection.Up);
                break;
            case HoopDirection.Right:
                directions.Add(HoopDirection.Right);
                directions.Add(HoopDirection.Up);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        var index = Random.Range(0, directions.Count);
        direction = directions[index];
        switch (direction)
        {
            case HoopDirection.Up:
                transform.position = lastHoop.transform.position + new Vector3(0, spacing, 0);
                break;
            case HoopDirection.Down:
                transform.position = lastHoop.transform.position + new Vector3(0, -spacing, 0);
                break;
            case HoopDirection.Left:
                transform.position = lastHoop.transform.position + new Vector3(-spacing, 0, 0);
                break;
            case HoopDirection.Right:
                transform.position = lastHoop.transform.position + new Vector3(spacing, 0, 0);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

[Serializable]
public enum HoopDirection
{
    Up,
    Down,
    Left,
    Right
}