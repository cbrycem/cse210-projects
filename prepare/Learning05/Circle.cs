using System;
using System.Net.NetworkInformation;

class Circle : Shape
{
    public Circle(string color, double radius) : base (color) {
        _radius = radius;
    }
    private double _radius;
    public override double GetArea() {
        return 3.14 * _radius * _radius;
    }
}