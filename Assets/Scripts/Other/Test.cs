using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void PrintShapeArea(Shape shape)
    {
        Console.WriteLine(shape.CalculateArea());
    }
    
    private void Start()
    {
        Shape rectangle = new Rectangle { Width = 5, Height = 4 };
        PrintShapeArea(rectangle); // Kết quả: 20
    
        Shape square = new Square { SideLength = 5 };
        PrintShapeArea(square); // Kết quả: 25
    }
}
internal class Shape
{
    protected internal virtual int CalculateArea()
    {
        return 0;
    }
}
class Rectangle : Shape
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }

    protected internal override int CalculateArea()
    {
        return Width * Height;
    }
}

class Square : Shape
{
    private int sideLength;

    public int SideLength
    {
        get => sideLength;
        set
        {
            sideLength = value;
        }
    }

    protected internal override int CalculateArea()
    {
        return sideLength * sideLength;
    }
}