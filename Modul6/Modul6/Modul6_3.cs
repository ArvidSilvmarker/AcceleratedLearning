using System;
using System.Collections.Generic;
using System.Text;

namespace Modul6
{
    class Modul6_3
    {
        public void Run()
        {
            var shapes = new List<Shape>();
            shapes.Add(new Triangle(3, 4, 10, 12));
            shapes.Add(new Rectangle(5,6, 14, 16));
            shapes.Add(new Circle(7,8, 20));

            foreach (var shape in shapes)
                Console.WriteLine(shape.ToString());  
        }
    }

    class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Shape(int x, int y)
        {
            X = x;
            Y = y;
        }   
        public override string ToString()
        {
            return $"I'm a {GetNameOfType()} with position x={X}, y={Y}";
        }

        public string GetNameOfType()
        {
            var array = GetType().ToString().Split('.');
            return array[array.Length - 1];
        }
      
    }

    class Circle : Shape
    {
        public int Radius { get; set; }

        public Circle(int x, int y, int radius) : base(x, y)
        {
            Radius = radius;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, radius={Radius}";
        }

    }

    class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int x, int y, int width, int height) : base(x, y)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Width={Width} and height={Height}";
        }
    }

    class Triangle : Shape
    {
        public int BaseLength { get; set; }
        public int Height { get; set; }

        public Triangle(int x, int y, int baseLength, int height) : base(x, y)
        {
            BaseLength = baseLength;
            Height = height;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, base length={BaseLength} and height={Height}";
        }
    }
}
