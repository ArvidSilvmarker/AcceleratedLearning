using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;

namespace Modul11
{
    class Modul11_1
    {
        public delegate string Nöff(string str);
        public void Run()
        {
            var parser = new Parser();
            List<string> list = parser.CreateListOfNames("PersonShort.csv");

            PrintSorted(list);
            PrintFiltered(list, "j");
            PrintFilteredManipulated(list, 'j', (str) => str.ToUpper(), (str) => str.Substring(1));

            Console.ReadKey();
        }

        private void PrintFilteredManipulated(List<string> list, char c, params Nöff[] methods)
        {
            Console.WriteLine("Filtered & manipulated:");
            list.Sort();
            foreach (var s in list)
            {
                if (Char.ToLower(s[0]) == Char.ToLower(c))
                {
                    string m = s;
                    foreach (var method in methods)
                    {
                        m = Noffify(m, method);
                    }
                    Console.WriteLine(m);
                }
            }

            Console.WriteLine();
        }

        private string Noffify(string text, Nöff method)
        {
            return method(text);
        }

        private void PrintFiltered(List<string> list, string c)
        {
            Console.WriteLine("Filtered:");
            list.Sort();
            foreach (var s in list)
            {
                if (s.ToLower().StartsWith(c.ToLower()))
                    Console.WriteLine(s);
            }

            Console.WriteLine();
        }

        private void PrintSorted(List<string> list)
        {
            Console.WriteLine("Sorted:");
            list.Sort();
            foreach (var s in list)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();
        }
    }


    public class Parser
    {
        public string Path { get; set; }

        public Parser(string path)
        {
            Path = path;
        }

        public Parser()
        {
            Path = @"c:\temp\";
        }

        public List<string> CreateListOfNames(string filename)
        {
            
            string[] lineArray = File.ReadAllLines(Path+filename);
            List<string[]> listArray = new List<string[]>();
            foreach (string line in lineArray)
                listArray.Add(line.Split(',',StringSplitOptions.RemoveEmptyEntries));

            listArray.RemoveAt(0);
            List<string> list = new List<string>();
            foreach (string[] text in listArray)
            {
                list.Add(text[1]+" "+text[2]);
            }

            return list;

        }
    }
}
