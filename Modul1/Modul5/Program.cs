using System;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace Modul5
{
    class Program
    {
        static void Main(string[] args)
        {
            Modul5_3.Exercise5_3();
        }

        //
        //
        // Exersive 5.3 Extrauppgift 3
        
        private static void Exercise5_1_3()
        {
            string repeatme = GetRepeatedTextFromUser();
            int startCycles = GetIntFromUser("Antal cykler: ");
            int sets = GetIntFromUser("Antal försök: ");

            string[,] testResults_iterative = new string[sets, 3];
            int cycles = startCycles;
            for (int i = 0; i < sets; i++)
            {
                TimeSpan timeElapsed = RunTest_Iterative(repeatme, cycles);

                testResults_iterative[i, 0] = cycles.ToString();
                testResults_iterative[i, 1] = (repeatme.Length * cycles).ToString();
                testResults_iterative[i, 2] = timeElapsed.TotalMilliseconds.ToString();
            }

            string[,] testResults_Stringbuilder = new string[sets, 3];
            cycles = startCycles;
            for (int i = 0; i < sets; i++)
            {
                TimeSpan timeElapsed = RunTest_Stringbuilder(repeatme, cycles);

                testResults_Stringbuilder[i, 0] = cycles.ToString();
                testResults_Stringbuilder[i, 1] = (repeatme.Length * cycles).ToString();
                testResults_Stringbuilder[i, 2] = timeElapsed.TotalMilliseconds.ToString();
            }

            WriteText("STRING TEST", ConsoleColor.Green);
            Console.Write("\n\n");
            WriteResult(testResults_iterative);
            Console.Write("\n\n");
            WriteText("STRINGBUILDER TEST", ConsoleColor.Green);
            Console.Write("\n\n");
            WriteResult(testResults_Stringbuilder);
            Console.Write("\n\n");

        }


        //
        //
        // Exercise 5.1 & 5.2

        private static void Exercise5_1()
        {
            string repeatme = GetRepeatedTextFromUser();
            int startCycles = GetIntFromUser("Antal cykler i första försöket: ");
            int increase = GetIntFromUser("Ökning per försök: ");
            int sets = GetIntFromUser($"Antal försök (x{increase} ökning per försök): ");


            string[,] testResults_iterative = new string[sets, 3];
            int cycles = startCycles;
            for (int i = 0; i < sets; i++)
            {
                TimeSpan timeElapsed = RunTest_Iterative(repeatme, cycles);

                testResults_iterative[i, 0] = cycles.ToString();
                testResults_iterative[i, 1] = (repeatme.Length * cycles).ToString();
                testResults_iterative[i, 2] = timeElapsed.TotalMilliseconds.ToString();

                cycles = cycles * increase;
            }

            string[,] testResults_Stringbuilder = new string[sets, 3];
            cycles = startCycles;
            for (int i = 0; i < sets; i++)
            {
                TimeSpan timeElapsed = RunTest_Stringbuilder(repeatme, cycles);

                testResults_Stringbuilder[i, 0] = cycles.ToString();
                testResults_Stringbuilder[i, 1] = (repeatme.Length * cycles).ToString();
                testResults_Stringbuilder[i, 2] = timeElapsed.TotalMilliseconds.ToString();

                cycles = cycles * increase;
            }

            WriteText("STRING TEST", ConsoleColor.Green);
            Console.Write("\n\n");
            WriteResult(testResults_iterative);
            Console.Write("\n\n");
            WriteText("STRINGBUILDER TEST", ConsoleColor.Green);
            Console.Write("\n\n");
            WriteResult(testResults_Stringbuilder);
            Console.Write("\n\n");


        }

        private static void WriteText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        private static void WriteResult(string[,] testResults)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Cycles\t\tLength of string\tTime");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < testResults.GetLength(0); i++)
                Console.WriteLine($"{testResults[i, 0]}\t\t{testResults[i, 1]}\t\t\t{testResults[i, 2]}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Median time: {CalculateMedian(testResults)}");
            Console.ResetColor();

        }

        private static double CalculateMedian(string[,] testResults)
        {
            List<double> times = new List<double>();
            for (int i = 0; i<testResults.GetLength(2); i++)
                times.Add(Convert.ToDouble(testResults[i, 2]));
            times.Sort();
            if (times.Count % 2 == 0)
                return 0;

            else
                return 0;

        }

        private static TimeSpan RunTest_Iterative(string repeatme, int startCycles)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            string generatedString = GenerateString_Iterative(repeatme, startCycles);
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        private static TimeSpan RunTest_Stringbuilder(string repeatme, int startCycles)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            string generatedString = GenerateString_Stringbuilder(repeatme, startCycles);
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        private static TimeSpan RunTest_Recursive(string repeatme, int startCycles)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            string generatedString = GenerateString_Recursive(repeatme, startCycles);
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        private static int GetIntFromUser(string text)
        {
            Console.Write(text);
            return Convert.ToInt32(Console.ReadLine());
        }

        private static int GetSetsFromUser()
        {
            Console.Write("Antal set (x10 per set): ");
            return Convert.ToInt32(Console.ReadLine());
        }

        private static string GetRepeatedTextFromUser()
        {
            Console.Write("Text att repetera: ");
            return Console.ReadLine();
        }

        private static string GenerateString_Recursive(string repeatme, int cycles)
        { 
            if (cycles > 1)
                return GenerateString_Recursive(repeatme, cycles - 1) + repeatme;
            else
                return repeatme; 
        }

        private static string GenerateString_Iterative(string repeatme, int cycles)
        {
            string result = "";
            for (int i = 0; i < cycles; i++)
                result = result + repeatme;
            return result;
        }

        private static string GenerateString_Stringbuilder(string repeatme, int cycles)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < cycles; i++)
                result.Append(repeatme);
            return result.ToString();
        }
    } 


}
