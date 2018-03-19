using System;
using System.Collections.Generic;
using System.Text;

namespace Modul5
{
    public class Point
    {
        public int X { get; set; }

        public int Y { get; set; }




        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void MovePoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public string DisplayPoint()
        {
            return ($"Point=({this.X},{this.Y})");
        }
    }

    public struct Point_Struct
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point_Struct(int x, int y)
        {
            X = x;
            Y = y;
        }
        public string DisplayPoint()
        {
            return ($"Point=({this.X},{this.Y})");
        }
    }
}
