using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Holder : MonoBehaviour
{
    public Direction direction;
    public TextMeshPro idText;
    public SpriteRenderer spriteRenderer;

    public void Init(int id)
    {
        name = "Hoop" + id;
        idText.text = id.ToString();
        spriteRenderer.color = Color.yellow;
    }

    public void InitFollowLastHolder(Holder lastHolder, int id, float spacing)
    {
        Init(id);
        var directions = new List<Direction>();
        switch (lastHolder.direction)
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
            default:
                throw new ArgumentOutOfRangeException();
        }

        var index = Random.Range(0, directions.Count);
        direction = directions[index];
        switch (direction)
        {
            case Direction.Up:
                transform.position = lastHolder.transform.position + new Vector3(0, spacing, 0);
                break;
            case Direction.Down:
                transform.position = lastHolder.transform.position + new Vector3(0, -spacing, 0);
                break;
            case Direction.Left:
                transform.position = lastHolder.transform.position + new Vector3(-spacing, 0, 0);
                break;
            case Direction.Right:
                transform.position = lastHolder.transform.position + new Vector3(spacing, 0, 0);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    // [Button]
    // public abstract void Complete();
    public void Complete()
    {
        spriteRenderer.color = Color.green;
        idText.gameObject.SetActive(false);
    }
}

[Serializable]
public enum Direction
{
    Up,
    Down,
    Left,
    Right
}