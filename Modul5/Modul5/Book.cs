using System;
using System.Collections.Generic;

namespace Modul5
{
    class BookProgram
    {
        public static void Run()
        {
            var b1 = new Book();
            b1.Pages = 2000;
            if (b1.Pages < 0)
            {
                Console.WriteLine("Fel input!");
            }
            else
            {
                Console.WriteLine($"Pages: {b1.Pages}");
                Console.WriteLine($"Weight: {b1.Weight}");
                Console.WriteLine($"Review: {b1.Review}");
            }

        }
    }

    class Product
    {
        public int ProductID { get; set; }

    }

    class Book : Product
    {
        public int ISBN { get; set; }
        public string Author { get; set; }

        private int _pages;
        public int Pages {

            get => _pages;

            set
            {
                _pages = value;
                Weight = value * WEIGHTPERPAGE;
                Review = value < 100 ? "Bra bok!" : "Dålig bok!";
            }
        }

        public int Weight { get; set; }
        public string Review { get; set; }
        private const int WEIGHTPERPAGE = 3;

    }

    class EBook : Book
    {
        public void SendAsEmail(string adress)
        {
            Console.WriteLine("Ebook: " + adress);
        }
    }
}
