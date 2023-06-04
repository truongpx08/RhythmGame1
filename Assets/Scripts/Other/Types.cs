using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Types
{
}

[Serializable]
public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

[Serializable]
public class BoxName
{
    public const string NormalBox = "NormalBox";
    public const string ReverseBox = "ReverseBox";
    public const string SpeedUpBox = "SpeedUpBox";
    public const string SpeedDownBox = "SpeedDownBox";
    public const string LockBox = "LockBox";
}