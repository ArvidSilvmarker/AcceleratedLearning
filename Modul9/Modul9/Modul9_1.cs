using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Modul9
{
    public class Modul9_1
    {
        public void Run()
        {
            string question = "Enter a string to convert: ";
            GetInputAndConvert(question, ToUpper);
            GetInputAndConvert(question, TrippleText);
            GetInputAndConvert(question, AddStars);


        }

        private void GetInputAndConvert(string text, Func<string, string> Convert)
        {
            Console.Write(text);
            Console.WriteLine($"Here is the result: {Convert(Console.ReadLine())}");
            Console.WriteLine();
        }

        private string ToUpper(string text)
        {
            return text.ToUpper();
        }

        private string AddStars(string input)
        {
            List<char> output = new List<char>();
            foreach (var ch in input)
            {
                output.Add(ch);
                output.Add('*');
            }

            output.RemoveAt(output.Count-1);

            string text = "";
            foreach (char ch in output)
                text += ch;

            return text;
        }

        private string RepeatText(string input, int count)
        {
            string output = "";
            for (int i = 0; i < count; i++)
                output += input;
            return output;
        }

        private string TrippleText(string input)
        {
            return RepeatText(input, 3);
        }
    }
}
