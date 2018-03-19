using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Modul2
{ 

    enum Rainbow { DarkMagenta, Magenta, DarkBlue, Blue, Cyan, Green, DarkYellow, Yellow, Red }


//    All the foreground colors except DarkCyan, the background color:
//       The foreground color is Black.
//       The foreground color is DarkBlue.
//       The foreground color is DarkGreen.
//       The foreground color is DarkRed.
//       The foreground color is DarkMagenta.
//       The foreground color is DarkYellow.
//       The foreground color is Gray.
//       The foreground color is DarkGray.
//       The foreground color is Blue.
//       The foreground color is Green.
//       The foreground color is Cyan.
//       The foreground color is Red.
//       The foreground color is Magenta.
//       The foreground color is Yellow.
//       The foreground color is White.
    class Program
    {
        

        static void Main(string[] args)
        {
            Exercise2_2();

        }



        //
        //
        // 2.3 (den med frukter)
        static void Exercise2_3()
        {
            Console.Write("Hur många frukter? ");
            var fruits = GetFruits(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine();

            string concatText = "Concatenated fruits: " + fruits[0] + ", " + fruits[1] + ", " + fruits[2] + "!";
            //Console.WriteLine(concatText);
            Console.WriteLine("Concatenated fruits: " + ConcatenatedString(fruits));

            //Console.WriteLine($"Placeholder fruits: {0}, {1}, {2}!", fruits[0], fruits[1], fruits[3]);
            //Console.WriteLine("Placeholden fruits: " + PlaceholderString(fruits));

            //Console.WriteLine($"Interpolated fruits: {fruits[0]}, {fruits[1]}, {fruits[2]}!");
            //Console.WriteLine("Interpolated fruits: " + InterpolatedString(fruits[0], fruits[1], fruits[2]));

        }

        static string Builder(List<string> textList)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < textList.Count; i++)
            {
                builder.Append(textList[i]);
                if (i < (textList.Count - 1))
                {
                    //Console.WriteLine(textString + " " + i);
                    builder.Append(", ");
                }
                else
                {
                    //Console.WriteLine(textString + " " + i);
                    builder.Append("!");
                }
            }
            return builder.ToString();

        }

        static string ConcatenatedString(List<string> textList)
        {
            string textString = ""; 
            for (int i = 0; i < textList.Count; i++)
            {
                textString = textString + textList[i];
                if (i < (textList.Count - 1))
                {
                    //Console.WriteLine(textString + " " + i);
                    textString = textString + ", ";
                }
                else
                {
                    //Console.WriteLine(textString + " " + i);
                    textString = textString + "!";
                }
            }
            return textString;
        }

        static string PlaceholderString(List<string> text)
        {
            return String.Format("{0}, {1}, {2}!", text[0], text[1], text[2]);

        }

        static string InterpolatedString(string fruit1, string fruit2, string fruit3)
        {
            return $"{fruit1}, {fruit2}, {fruit3}!";
            
        }

        static List<string> GetFruits(int count)
        {
            var fruits = new List<string>();
            for (int i = 0; i < count; i++)
            {
                Console.Write("Enter fruit " + (i+1) + ": ");
                fruits.Add(Console.ReadLine().ToLower().Trim());
            }
            return fruits;
        }

        //
        // 2.2 (Den med namn och ålder)
        //


        static void Exercise2_2()
        {
            string name = "";
            int age = 0;
            char character = ' ';
            Random random = new Random();


            var order = RandomList(3);

            foreach (var a in order)
            {
                switch (a)
                {
                    case 0:
                        name = GetName();
                        break;
                    case 1:
                        age = GetAge();
                        break;
                    case 2:
                        character = GetCharacter();
                        break;
                }
            }




            Console.WriteLine();
            Console.WriteLine("Tack!");
            Console.WriteLine();

            if (name == "Arvid" && age == 37)
                Console.Beep();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hejsan " + name + "!");
            Console.WriteLine("Du har " + (65-age) + "år kvar till pension (inte illa).");
            if (char.IsDigit(character))
                Console.WriteLine("Du gillar inte bokstäver?");
            else
                Console.WriteLine("Du gillar inte siffror?");
            Console.ResetColor();
            Console.WriteLine();
        }

        static List<int> RandomList(int count)
        {
            var randomList = new List<int>();
            var random = new Random();

            while (randomList.Count < count)
            {
                int MyNumber = random.Next(0, count);
                if (!randomList.Contains(MyNumber))
                    randomList.Add(MyNumber);
            }

            return randomList;
        }

        static string GetName()
        {
            Console.Write("Vad heter du? ");
            return Console.ReadLine();
        }

        static int GetAge()
        {
            Console.Write("Hur gammal är du? ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static char GetCharacter()
        {

            string character;
            while (true)
            {
                Console.Write("Vilken är din favoritkaraktär? ");
                character = Console.ReadLine();
                if (character.Length > 1)
                    Console.WriteLine("Jag gillar också " + character + " men jag menar mer bokstav eller siffra...");
                else
                    break;
            }
            return Convert.ToChar(character);
        }


        //
        // 2.1 (den med regnbågen)
        //
        static void Exercise2_1()
        {
            string name;
            string age;
            string letter;
            string food;
            string town;

            Console.Write("Vad heter du? ");
            name = Console.ReadLine();
            Console.Write("Hur gammal är du? ");
            age = Console.ReadLine();
            Console.Write("Vilken är din favoritbokstav? ");
            letter = Console.ReadLine();
            Console.Write("Vilken är din älsklingsrätt? ");
            food = Console.ReadLine();
            Console.Write("Var bor du? ");
            town = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Tack!");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hejsan " + name + "!");
            Console.WriteLine("Du är " + age + " år gammal (inte illa).");
            Console.WriteLine("Vadan detta intresse för bokstaven " + letter + "?");
            Console.WriteLine("Jag gillar också " + food.ToLower() + "!");
            Console.WriteLine("Är " + town + " en trevlig stad?");
            Console.ResetColor();
        }

        static string Rainbowize(String text)
        {

            return text;

        }
    }
}
