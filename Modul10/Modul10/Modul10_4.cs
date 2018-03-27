using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Modul10
{
    class Modul10_4
    {
        public void Run()
        {
            var dic = new Dictionary<char, int> {{'A', 35}, {'B', 45}, {'C', 68}};
            Console.WriteLine(dic['B']);
            Console.WriteLine(dic.ContainsKey('F'));

        }

        private void InfiniteNumbers()
        {
            List<int> numbers = new List<int>();
            while (true)
            {
                string text = AskForNumber();
                if (text.Trim().ToLower() == "quit")
                    break;
                numbers.Add(Convert.ToInt32(text));

            }

            double sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }

            Console.WriteLine($"Average: {(double)(sum/numbers.Count):N}");

            numbers.Sort();
            if (numbers.Count % 2 == 0)
            {
                int middle = numbers.Count / 2;
                //Console.WriteLine(middle);
                double a = numbers[middle-1];
                double b = numbers[middle];
                Console.WriteLine($"Median: {a} + {b} / 2 = {(a+b)/2.0}");

            }
            else
            {
                Console.WriteLine($"Median: {numbers[(int)Math.Floor(numbers.Count/2.0)]}");
            }

        }

        private void InfiniteNames()
        {
            List<string> names = new List<string>();
            while (true)
            {
                string name = AskForName();
                if (name.Trim().ToLower() == "quit")
                    break;
                names.Add(name);
                
            }

            names.Sort();
            names.RemoveAt(names.Count-1);
            names.RemoveAt(0);

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        private string AskForName()
        {

            Console.Write("Write a name: ");
            return Console.ReadLine();
        }

        private string AskForNumber()
        {

            Console.Write("Write a number: ");
            return Console.ReadLine();
        }

        public List<string> LoadJson()
        {
            List<string> monsters = new List<string>();
            using (StreamReader r = new StreamReader(@"C:\temp\file.json"))
            {
                string json = r.ReadToEnd();

                dynamic array = JsonConvert.DeserializeObject(json);
                foreach (string a in array)
                {
                    monsters.Add(a);
                }
            }

            return monsters;

        }


        public void SaveJson()
        {




            List<string> data = new List<string>();
            data.Add("Werewolf");
            data.Add("Vampire");
            data.Add("Mummy");
            data.Add("Zombie");
            string json = JsonConvert.SerializeObject(data.ToArray());

            File.WriteAllText(@"C:\temp\file.json", json);



        }


    }
}


