using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Modul_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Exercise4_3();
        }

        //
        //
        //
        // Exercise 4.3 

        static void Exercise4_3()
        {
            do
            {
                List<string> nameList = GetInputList();
                nameList = MakeSuper(nameList);
                WriteText(nameList, ConsoleColor.Green);
            } while (GetYesOrNo("Kör igen (ja/nej): "));


        }



        //
        //
        // Exercise 4.2 (Skriv en egen Trim())

        static void Exercise4_2()
        {
            string[] nameArray = GetInputArray("Skriv in namn (Adam, Bertil, Cesar...): ");

            char[] cleanUpChars = { ' ', '%', '&' };
            nameArray = CleanText(nameArray, cleanUpChars);

            WriteText(nameArray, ConsoleColor.Cyan);

        }

        //
        //
        // Exercise 4.1 (den med superhjälte)

        static void Exercise4_1()
        {
            Console.Write("Skriv in namn (Adam, Bertil, Cesar...): ");
            string[] nameArray = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < nameArray.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                if (!String.IsNullOrWhiteSpace(nameArray[i]))
                    Console.WriteLine($"***SUPER-{nameArray[i].Trim().ToUpper()}***");
            }
        }

        static void Exercise4_1_variant()
        {
            List<string> nameList = GetInputList();
            nameList = MakeSuper(nameList);
            WriteText(nameList, ConsoleColor.Magenta);
        }


        //
        //
        // Generic methods

        static void WriteText(List<string> nameList, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            foreach (var name in nameList)
            {
                Console.WriteLine(name);
            }
            Console.ResetColor();
        }

        static void WriteText(string[] nameList, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            foreach (var name in nameList)
            {
                Console.WriteLine(name);
            }
            Console.ResetColor();
        }

        static void WriteText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static List<string> MakeSuper(List<string> nameList)
        {
            var superList = new List<string>();
            foreach (var name in nameList)
            {
                if (!String.IsNullOrWhiteSpace(name))
                    superList.Add($"***SUPER-{name.Trim().ToUpper()}***");
            }
            return superList;

        }

        static string[] MakeSuper(string[] nameList)
        {
            var superList = new List<string>();
            foreach (var name in nameList)
            {
                if (!String.IsNullOrWhiteSpace(name))
                    superList.Add($"***SUPER-{name.Trim().ToUpper()}***");
            }
            return superList.ToArray();

        }

        static char[] AskUserForSeparator()
        {
            char[] separatorChars;
            while (true)
            {
                Console.Write("Skriv in skiljetecken (,;-): ");
                separatorChars = Console.ReadLine().ToCharArray();
                if (!ValidateSeparatorArray(separatorChars))
                    continue;
                break;
            }
            return separatorChars;
        }

        static bool ValidateSeparatorArray(char[] separatorChars)
        {
            if (separatorChars.Length > 0)
                return true;
            return false;
        }

        static List<string> GetInputList()
        {
            char[] separatorChars = AskUserForSeparator();
            bool wantsErrorMessage = GetYesOrNo("Se felmeddelanden (ja/nej): ");
            return AskUserForNames(separatorChars, wantsErrorMessage);
        }

        static List<string> AskUserForNames(char[] separatorChars, bool wantsErrorMessage)
        {
            List<string> nameList = new List<string>();
            while (true)
            {
                Console.Write("Skriv in namn (Adana, Berit, Cecilia): ");
                nameList = Console.ReadLine().Split(separatorChars, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                nameList = CleanText(nameList);

                if (!ValidateText(nameList, wantsErrorMessage))
                    continue;
                break;

            }
            return nameList;
        }


        public static bool ValidateText(List<string> nameList, bool wantsErrorMessage)
        {
            bool validInput = true;
            List<string> errorMessage = new List<string>();


            if (nameList == null)
            {
                WriteText("Namnlistan får inte vara null.", ConsoleColor.Red);
                return false;
            }

            if (nameList.Count == 0)                                                
            {
                errorMessage.Add("Måste ha minst ett namn.");
                validInput = false;    
            }

            foreach (var name in nameList)
            {
                if (name == null)
                {
                    WriteText("Ett namn får inte vara null.", ConsoleColor.Red);
                    return false;
                }

                if (name.Length < 2 || name.Length > 9)
                {
                    errorMessage.Add("Ett namn måste ha 2-9 bokstäver.");
                    validInput = false;
                }


                for (int i = 0; i < name.Length; i++)
                {
                    if (!Char.IsLetter(name[i]))
                    {
                        errorMessage.Add("Ett namn får bara innehålla bokstäver.");
                        validInput = false;
                    }
                    if (i == 0 && Char.IsLower(name[i]))
                    {
                        errorMessage.Add("Första bokstaven måste vara versal.");
                        validInput = false;
                    }
                    if (i > 0 && Char.IsUpper(name[i]))
                    {
                        errorMessage.Add("Bokstäver efter första måste vara gemener.");
                        validInput = false;
                    }
                }
            }

            if (wantsErrorMessage)
                WriteText(errorMessage, ConsoleColor.Red);

            return validInput;
        }

        static string[] GetInputArray(string text)
        {
            Console.Write(text);
            return Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
        }

        static string[] CleanText(string[] array, char[] cleanUpChars)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int start = 0;
                int end = 0;



                for (int j = 0; j < array[i].Length; j++)    //Check removeable characters from the front
                {
                    if (cleanUpChars.Contains(array[i][j]))
                        start++;
                    else
                        break;
                }

                array[i] = array[i].Remove(0, start);       //remove those characters


                for (int j = array[i].Length-1; j >= 0; j--)    //Check removeable characters from the back
                {
                    if (cleanUpChars.Contains(array[i][j]))
                        end++;
                    else
                        break;
                }

                array[i] = array[i].Remove(array[i].Length-end, end);
            }

            return array;
        }

        static List<string> CleanText(List<string> names)
        {
            for (int i = 0; i < names.Count; i++)
            {
                names[i] = names[i].Trim();
            }
            return names;
        }

        static bool GetYesOrNo(string text)
        {
            string[] affirmativeStrings = GetYes();
            string[] negativeStrings = GetNo();
            
            while (true)
            {
                Console.Write(text);
                string answer = Console.ReadLine().Trim().ToLower();
                if (affirmativeStrings.Contains(answer))
                    return true;
                else if (negativeStrings.Contains(answer))
                    return false;
            }

        }

        static string[] GetYes()
        {
            string path = @"C:\Project\CSharpExercises\Modul1\Modul 4\Yes.txt";
            string text = File.ReadAllText(path);
            return (text.Split(',',StringSplitOptions.RemoveEmptyEntries));

        }

        static string[] GetNo()
        {

            string path = @"C:\Project\CSharpExercises\Modul1\Modul 4\No.txt";
            string text = File.ReadAllText(path);
            return (text.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }


    }



}
