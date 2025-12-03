using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Square s = new Square("Blue", 5);
        Console.WriteLine("Testing Square:");
        Console.WriteLine($"Color: {s.GetColor()}");
        Console.WriteLine($"Area: {s.GetArea()}");
        Console.WriteLine();

        Rectangle r = new Rectangle("Red", 4, 6);
        Circle c = new Circle("Green", 3);

        Console.WriteLine("Testing Rectangle:");
        Console.WriteLine($"Color: {r.GetColor()}");
        Console.WriteLine($"Area: {r.GetArea()}");
        Console.WriteLine();

        Console.WriteLine("Testing Circle:");
        Console.WriteLine($"Color: {c.GetColor()}");
        Console.WriteLine($"Area: {c.GetArea()}");
        Console.WriteLine();

        List<Shape> shapes = new List<Shape>();
        shapes.Add(s);
        shapes.Add(r);
        shapes.Add(c);

        Console.WriteLine("Iterating through the list of shapes:");
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea()}");
            Console.WriteLine("----------------------");
        }
    }
}