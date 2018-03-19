using System;
using System.Collections.Generic;
using System.Text;

namespace Modul5
{
    class Modul5_3
    {
        public static void Exercise5_3()
        {
            Point point = new Point(3, 4);
            Console.WriteLine("Point");
            Console.WriteLine($"Before:\t\t{DisplayPoint(point)}");
            ChangePoint(point);
            Console.WriteLine($"After:\t\t{DisplayPoint(point)}");
            Console.WriteLine();

            StringBuilder sb = new StringBuilder("Let's go dancing");
            Console.WriteLine("Stringbuilder");
            Console.WriteLine($"Before:\t\t{sb}");
            ChangeStringBuilder(sb);
            Console.WriteLine($"After:\t\t{sb}");
            Console.WriteLine();

            Animal animal = new Animal("Nisse", 4);
            Console.WriteLine("Animal");
            Console.WriteLine($"Before:\t\t{DisplayAnimal(animal)}");
            ChangeAnimal(animal);
            Console.WriteLine($"After:\t\t{DisplayAnimal(animal)}");
            Console.WriteLine();

            string fruit = "Apple";
            Console.WriteLine("Fruit");
            Console.WriteLine($"Before:\t\t{fruit}");
            ChangeFruit(fruit);
            Console.WriteLine($"After:\t\t{fruit}");
            Console.WriteLine();

            int age = 25;
            Console.WriteLine("Age");
            Console.WriteLine($"Before:\t\t{age}");
            ChangeAge(age);
            Console.WriteLine($"After:\t\t{age}");
            Console.WriteLine();

            DateTime dt = new DateTime();
            Console.WriteLine("Date");
            Console.WriteLine($"Before:\t\t{dt.Date}");
            ChangeDate(dt);
            Console.WriteLine($"After:\t\t{dt.Date}");
            Console.WriteLine();

            Point_Struct pt = new Point_Struct(3, 4);
            Console.WriteLine("Point_Struct");
            Console.WriteLine($"Before:\t\t{pt.X},{pt.Y}");
            ChangePoint(pt);
            Console.WriteLine($"After:\t\t{pt.X},{pt.Y}");
            Console.WriteLine();

        }

        private static void ChangePoint(Point point)
        {
            point.X = 888;
            point.Y = 999;
        }
        private static void ChangeAnimal(Animal animal)
        {
            animal.cutOfLegs();
        }

        static void ChangeFruit(string fruit)
        {
            fruit = "Banana";
        }
        static void ChangeAge(int age)
        {
            age = 12;
        }
        static void ChangeDate(DateTime date)
        {
            date.AddDays(100);
        }
        static void ChangePoint(Point_Struct point)
        {
            point.X = 888;
            point.Y = 999;
        }

        private static string DisplayPoint(Point point)
        {
            return point.DisplayPoint(); ;
        }
        private static string DisplayAnimal(Animal animal)
        {
            return animal.DisplayAnimal(); ;
        }

        private static void ChangeStringBuilder(StringBuilder sb)
        {
            sb.Append(" Yes that would be great!");
        }
    }
}
