using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Text;

namespace Modul6
{
    class Modul6_2
    {
        public void Run()
        {
            Cube mycube = new Cube(2, 3, 4, ConsoleColor.Red);
            Cube supercube = new Cube(100, 200, 300);


            double volume = mycube.CalculateVolume();
            Console.WriteLine($"Area: {mycube.CalculateArea()}");
            Console.WriteLine($"Volume: {volume}");
            mycube.WriteColor();


            supercube.PaintItBlack();
            double supervolume = supercube.CalculateVolume();
            Console.WriteLine($"Area: {supercube.CalculateArea()}");
            Console.WriteLine($"Volume: {supervolume}");
            supercube.WriteColor();
            Console.WriteLine();
            Console.WriteLine($"The difference in areas is {supercube.AreaDifference(mycube)}");
        }
    }

    class Cube
    {
        public int Height { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public ConsoleColor Color { get; set; }

     
        public Cube(int h, int l ,int w)
        {
            Height = h;
            Length = l;
            Width = w;
            Color = ConsoleColor.DarkCyan;
        }

        public Cube(int h, int l, int w, ConsoleColor color)
        {
            Height = h;
            Length = l;
            Width = w;
            Color = color;
        }

        public void WriteVolume()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"Volume: {CalculateVolume()}");
            Console.ResetColor();
        }

        public double CalculateArea()
        {
            double area = Height * Length * 2 + Height * Width * 2 + Length * Width * 2;
            return area;
        }

        public double CalculateVolume()
        {
            return Height * Length * Width;
        }

        public void WriteColor()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"My color is {Color.ToString()}");
            Console.ResetColor();
        }

        public void PaintItBlack()
        {
            Color = ConsoleColor.Black;
        }

        public double AreaDifference(Cube otherCube)
        {
            return this.CalculateArea() - otherCube.CalculateArea();
        }

    }


}
