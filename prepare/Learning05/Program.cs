using System;
class Program
{
    static void Main(string[] args)
    {

        Square square = new Square("pink", 5);
        Rectangle rectangle = new Rectangle("Red", 10, 5);
        Circle circle = new Circle("Blue", 13);

        List<Shape> shapes =  new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes){
            Console.WriteLine($"The color of the {shape} is {shape.GetColor()}");
            Console.WriteLine($"The area of the {shape} is {shape.GetArea()}");
        }
    }
}
