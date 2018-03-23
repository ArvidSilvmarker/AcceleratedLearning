using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Modul9
{
    [Serializable]
    class Modul9_3
    {
        public delegate void MyAction();

        public event MyAction SpacePressed;

        public void Run()
        {
            SaveJson();
            string input = "";
            Console.WriteLine("Add from menu: ");
            Console.WriteLine("1: SetColorBlue");
            Console.WriteLine("2: SetBackgroundYellow");
            Console.WriteLine("3: WriteLine");
            Console.WriteLine("4: GiveMeCoffee");
            Console.WriteLine("5: ResetColor");
            Console.WriteLine("6: Read commands from file.");
            Console.WriteLine("Q: Ends input");
            while (input.ToLower() != "q")
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        SpacePressed += SetColorBlue;
                        break;
                    case "2":
                        SpacePressed += SetBackgroundYellow;
                        break;
                    case "3":
                        SpacePressed += WriteLine;
                        break;
                    case "4":
                        SpacePressed += GiveMeCoffee;
                        break;
                    case "5":
                        SpacePressed += ResetColor;
                        break;
                    case "6":
                        LoadJson();
                        break;
                }
            }



            Console.WriteLine("Space to Invoke. q to Quit.");

            while (true)
            {
                Char c = Console.ReadKey(true).KeyChar;

                if (c == ' ')
                    SpacePressed();
                if (c == 'q')
                    break;
            }

        }


        static void WriteLine()
        {
            Console.WriteLine("---------------");
        }

        static void GiveMeCoffee()
        {
            Console.WriteLine("Give me coffee!");
        }

        static void SetColorBlue()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        static void SetBackgroundYellow()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
        }

        static void ResetColor()
        {
            Console.ResetColor();
        }

        public void LoadJson()
        {

            using (StreamReader r = new StreamReader(@"C:\temp\file.json"))
            {
                string json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);
                foreach (string a in array)
                {
                    AddDelegateMethod(Delegate.CreateDelegate(typeof(MyAction), typeof(Modul9_3), a));
                }
            }

        }

        public void AddDelegateMethod(Delegate methodName)
        {
            SpacePressed += (MyAction)methodName;

        }

        public void SaveJson()
        {

            


            List<string> data = new List<string>();
            data.Add("SetColorBlue");
            data.Add("SetBackgroundYellow");
            data.Add("WriteLine");
            data.Add("GiveMeCoffee");
            data.Add("GiveMeCoffee");
            data.Add("ResetColor");
            string json = JsonConvert.SerializeObject(data.ToArray());

            File.WriteAllText(@"C:\temp\file.json", json);

            

        }


    }
}


