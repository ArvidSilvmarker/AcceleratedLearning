using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Modul8
{
    class Modul8_1
    {
        public void Run()
        {
            while (true)
            {
                try
                {
                    ChokolateDivider cd = new ChokolateDivider(24);
                    Console.WriteLine($"Antal choklatbitar att dela: {cd.PiecesOfChokolate}");
                    Console.Write("Antal personer: ");
                    int people = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Varje person får: {cd.Divide(people):0.00}");
                    break;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                    continue;
                }
            }

        }
    }

    class ChokolateDivider
    {
        public int PiecesOfChokolate { get; set; }

        public ChokolateDivider(int pieces)
        {
            PiecesOfChokolate = pieces;
        }

        public decimal Divide(int people)
        {
            if (people == 0) throw new DivideByZeroException("Noll personer kan inte dela på choklad.");
            if (people == 666) throw new DevilException();
            return (PiecesOfChokolate / (decimal)people);
        }
    }

    class DevilException : Exception
    {
        public DevilException(string message) : base(message)
        {
        }

        public DevilException() : base("Cookies of the Beast.")
        {
        }
    }
}
