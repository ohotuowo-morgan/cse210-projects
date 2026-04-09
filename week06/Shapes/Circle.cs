using System;
public class Circle : Shapes
{
    private double _pi = Math.PI;
    private double _radius;

    public Circle ( double radius, string color) : base (color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return _pi * _radius * _radius;
    }
}
