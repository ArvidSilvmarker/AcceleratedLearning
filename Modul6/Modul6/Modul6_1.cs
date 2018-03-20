using System;
using System.Collections.Generic;
using System.Text;

namespace Modul6
{
    class Modul6_1
    {
        public void Run()
        {
            var bob = new CircleOld("Bob", 8);
            var lisa = new Sphere("Lisa", 8);
            var ali = new HyperSphere("Ali", 8);

            bob.SayHello();
            lisa.SayHello();
            ali.SayHello();

            Console.WriteLine();

            bob.WriteArea();
            lisa.WriteArea();
            ali.WriteArea();
        }
    }

    class CircleOld
    {
        public string Name { get; set; }
        public double Radius { get; set; }
        public CircleOld(string name, double radius)
        {
            Name = name;
            Radius = radius;
        }

        public CircleOld(string name)
        {
            Name = name;
            Radius = 5;
        }

        public CircleOld()
        {
            Name = "Unknown";
            Radius = 5;
        }

        public void SayHello()
        {
            Console.WriteLine($"I'm a circle called {Name}");
        }

        public void WriteArea()
        {
            double area = Math.Round(Radius * Radius * Math.PI, 2); 
            Console.WriteLine($"I'm {Name} the circle and I have a radius of {Radius} and my area is {area}.");
        }
    }

    class Sphere : CircleOld
    {
        public Sphere(string name, double radius) : base(name, radius) { }
        public Sphere(string name) : base(name) { }
        public Sphere() : base() { }

        public new void WriteArea()
        {
            double area = Math.Round(4 * Radius * Radius * Math.PI, 2);
            Console.WriteLine($"I'm {Name} the sphere and I have a radius of {Radius} and my area is {area}.");
        }
    }

    class HyperSphere : Sphere
    {
        public HyperSphere(string name, double radius) : base(name, radius) { }

        public new void WriteArea()
        {
            double area = Math.Round(2 * Math.Pow(Radius, 3) * Math.Pow(Math.PI, 2), 2);
            Console.WriteLine($"I'm {Name} the hypersphere and I have a 4-dimensional radius of {Radius} and my hyperarea is {area}.");
        }

    }

}
