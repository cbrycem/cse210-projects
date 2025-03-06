using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> list = new List<Shape>();
        Square square = new Square("Red", 2);
        Rectangle rectangle = new Rectangle("Green", 2, 4);
        Circle circle = new Circle("Blue", 2);
        list.Add(square);
        list.Add(rectangle);
        list.Add(circle);

        foreach (Shape e in list) {
            Console.WriteLine(e.GetColor());
            Console.WriteLine(e.GetArea());
        }
    }
}