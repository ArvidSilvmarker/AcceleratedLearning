using System;
using System.Collections.Generic;
using System.Text;

namespace Modul10
{
    class Modul10_1
    {
        public void Run()
        {
            ThreeNamesWithArray();
        }

        void ThreeNamesWithArray()
        {
            string[] names = new string[3];
            for (int i = 0; i<names.Length; i++)
            {
                names[i] = AskForName();
            }

            foreach (var name in names)
            {
                Console.WriteLine($"Name: {name}");
            }

            Console.WriteLine(Scramble(names));
            Console.WriteLine(RepeatFirstLetter(names));
        }

        private string RepeatFirstLetter(string[] names)
        {
            string repeat = "";
            foreach (var name in names)
            {
                for (int i = 0; i < name.Length; i++)
                {
                    repeat += name[0].ToString();
                }
            }

            return repeat;
        }

        private string Scramble(string[] names)
        {
            string scrambedString = "";
            foreach (var name in names)
            {
                scrambedString += name.Substring(0, 2);
            }

            foreach (var name in names)
            {
                scrambedString += name.Substring(2);
            }

            return scrambedString;
        }

        private string AskForName()
        {

            Console.Write("Write a name: ");
            return Console.ReadLine();
        }
    }
}
