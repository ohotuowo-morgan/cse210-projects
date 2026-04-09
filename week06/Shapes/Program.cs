using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Square squ = new Square(2, "red");
        // Console.WriteLine($"{squ.GetColor()} and {squ.GetArea()}");

        Rectangle rec = new Rectangle(4, 5, "blue");
        // Console.WriteLine($"{rec.GetColor()} and {rec.GetArea()}");

        Circle cir = new Circle(3, "black");
        // Console.WriteLine($"{cir.GetColor()} and {cir.GetArea()}");

        List<Shapes> shapes = new List<Shapes>();
        shapes.Add(squ);
        shapes.Add(rec);
        shapes.Add(cir);

        foreach (Shapes s in shapes)
        {

            string color = s.GetColor();
            double area = s.GetArea();

            Console.WriteLine($"The color of the shape is {color} and its area  is {area}");
        }
        
        

    }
}