using System;
using System.Collections.Generic;
using System.Linq;


namespace Modul3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Exercise3_7();
        }

        //
        //
        // Exercuse 3.7 (OneLiner)


        static void Exercise3_7()
        {
            Console.WriteLine("Skriv nuffra: ");
            Console.WriteLine(OneLineCompare(Convert.ToInt32(Console.ReadLine())));

        }

        public static string OneLineCompare(int number)
        {
            return number > 20 ? "Större än 20" : number < 20 ? "Mindre än 20" : "Lika med 20";
        }

        public static string IfElseLineCompare(int number)
        {
            if (number > 20)
                return "Större än 20";
            else if (number < 20)
                return "Mindre än 20";
            else
                return "Lika med 20";
        }


        //
        //
        // Exercuse 3.6 (10-minutaren)

        static void Exercise3_6()
        {
            //Console.Write("Skriv nuffra: ");
            //int number = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine();
            //Console.Write("Jämförelse: ");
            //Console.WriteLine(Compare(number, 20));

            var random = new Random();
            int answer = random.Next(1, 101);
            int guessesLeft = 6;
            int guess;
            string reply;

            while (guessesLeft > 0)
            {
                Console.WriteLine($"Gissa ett tal. Du har {guessesLeft} gissningar kvar: ");
                guess = Convert.ToInt32(Console.ReadLine());
                reply = CompareGuess(guess, answer);
                if (reply.Contains("rätt"))
                {
                    Console.WriteLine(reply);
                    break;
                }
                else
                {
                    Console.WriteLine(reply);
                    guessesLeft--;
                }


                
            }


        }

        static string CompareGuess(int number, int compare)
        {
            if (number < compare)
                return $"{number} är mindre";
            else if (number == compare)
                return $"{number} är rätt";
            else if (number > compare)
                return $"{number} är större";
            else
                return "";

        }

        static string Compare(int number, int compare)
        {
            if (number < compare)
                return $"{number} är mindre än {compare}";
            else if (number == compare)
                return $"{number} är lika med {compare}";
            else if (number > compare)
                return $"{number} är större än {compare}";
            else
                return "";

        }





        //
        //
        //
        // Exercise 3.5 (den med foreach-loop med break och Zelda)

        static void Exercise3_5()
        {
            Console.Write("Ange namn (Adam, Bertil, David): ");
            List<string> names = GetCommaSeparatedWords(Console.ReadLine());

            Console.WriteLine();
            List<ZeldaPerson> zeldaList = ZeldaLogic(names);
            DisplayNamesZelda(zeldaList);
            Console.WriteLine();
            Console.ResetColor();

        }

        public static List<ZeldaPerson> ZeldaLogic(List<string> names)
        {
            List<ZeldaPerson> zeldaList = new List<ZeldaPerson>();

            foreach (var name in names)
            {
                
                if (!names.Contains("AllowZelda") && name == "Zelda")
                    break;
                else if (name == "Link")
                {
                    ZeldaPerson person = new ZeldaPerson();
                    person.color = ConsoleColor.DarkGreen;
                    person.name  = "Link, Savior of Hyrule";
                    zeldaList.Add(person);
                }
                else if (name != "AllowZelda")
                {
                    ZeldaPerson person = new ZeldaPerson();
                    person.color = ConsoleColor.Green;
                    person.name = name;
                    zeldaList.Add(person);
                }
                

            }

            return zeldaList;

        }


        static void DisplayNamesZelda(List<ZeldaPerson> persons)
        {
            foreach (ZeldaPerson person in persons)
            {
                Console.ForegroundColor = person.color;
                Console.WriteLine(person.name);
            }
            
        }


        //
        //
        //
        // Exercise 3.4 (den med foreach-loop och efternamn)

        static void Exercise3_4()
        {
            List<string> names = GetCommaSeparatedWords("Ange förnamn (Adam, Bertil, David): ");


            String surname = GetInput("Ange efternamn: ");
            if (String.IsNullOrWhiteSpace(surname))
            {
                surname = "Andersson";
                Console.WriteLine($"Standardefternamn: {surname}");
            }

            do
            {
                DisplayNames(names, surname, true);
                Console.WriteLine();
                int remove = GetRemove();
                if (remove == 0)
                    break;
                else
                    names = RemoveName(names, remove);

            } while (true);

            
        }

        static int GetRemove()
        {
            Console.WriteLine("Ange nummer att ta bort eller 0 för att inte ta bort någon: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static List<string> RemoveName(List<string> names, int remove)
        {
            names.RemoveAt(remove - 1);
            return names;
        }

        public static List<string> GetCommaSeparatedWords(string input){
            var trimmedList = new List<string>();
            bool validInput;

            do
            {
                trimmedList = new List<string>();
                validInput = true;

                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.Write("Måste ange namn: Försök igen: ");
                    validInput = false;
                }

                else
                {
                    var inputArray = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in inputArray)
                    {
                        if (String.IsNullOrWhiteSpace(word))
                        {
                            Console.Write("Måste ange namn. Försök igen: ");
                            validInput = false;
                        }
                        else if (word.Length > 20)
                        {
                            Console.WriteLine("För långt namn. Försök igen: ");
                            validInput = false;
                        }
                        else
                            trimmedList.Add(word.Trim());
                    }

                }


            } while(!validInput);

            return trimmedList;

        }

        static void DisplayNames(List<string> names, string surname, bool numbered)
        {
            int counter = 0;
            foreach (var name in names)
            {
                counter++;
                if (numbered)
                {
                    Console.Write($"[{counter}] ");
                }
                Console.WriteLine($"{name} {surname}");
            }
        }


        //
        //
        //
        // Exercise 3.3 (den med forloop)

        static void Exercise3_3()
        {

            int columns = GetTimes("Ange kolumner: ");
            int rows = GetTimes("Ange rader: ");
            string name = GetInput("Ange namn: ");
            int format = GetTimes("Ange format (0=fram+baklänges, 1-5 = repeterat) ");

            Repeat(columns, rows, name, format);
            //Repeat(columns, rows, name);
        }

        static void Repeat(int columns, int rows, string name)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{name}\t");
                }
                Console.Write("\n");
            }
        }

        static void Repeat(int columns, int rows, string name, int format)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (format == 0)
                        WriteForwardsAndBackwards(name);
                    else if (format > 0 && format < 5)
                    {
                        WriteMultiple(name, format);
                    }
                    else
                        Console.Write(name);
                    Console.Write("\t");
                }
                Console.Write("\n");
            }
        }

        static void WriteMultiple(string name, int format)
        {
            for (int i = 0; i < format; i++)
            {
                Console.Write(name);
            }
        }
        static void WriteForwardsAndBackwards(string name)
        {
            Console.Write(name);
            var charArray = name.ToCharArray();
            for (int i = (charArray.Length-1); i >= 0; i--)
            {
                Console.Write(charArray[i]);
            }
        }

        //
        //
        //
        // Exercise 3.2 (den med while-loop)

        static void Exercise3_2()
        {
            string name = GetInput("What is your name? ");
            int times = GetTimes("Number of times? ");
            bool line = GetInputFormat("One line or comma? ");

            //WhileType1(name, times);
            Console.WriteLine();
            WhileType2(name, times, line);
        }

        static void WhileType2(string name, int times)
        {
            int i = 0;
            while (i < times)
            {
                Conca("While (i < times): Your name is ",name);
                i++;
            }

        }

        static void WhileType2(string name, int times, bool line)
        {
            int i = 0;
            while (i < times)
            {
                Conca("Your name is ", name, line);
                i++;
            }

        }
        static void WhileType1(string name, int times)
        {
            int i = 0;
            while (true)
            {
                if (i == times)
                    break;
                PlaceHolder("While (true): Your name is ", name);

                Interpolate("Interpolated ", name);
                i++;
            }

        }

        static void Conca(string text1, string text2)
        {
            Console.WriteLine(text1 + text2);
        }

        static void Conca(string text1, string text2, bool line)
        {
            if (line)
                Console.WriteLine(text1 + text2);
            else
            {
                Console.Write(text1 + text2 + ", ");
            }
        }
        static void PlaceHolder(string text1, string text2)
        {
            Console.WriteLine("{0}{1}", text1, text2);
        }

        static void Interpolate(string text1, string text2)
        {
            Console.WriteLine($"{text1}{text2}");
        }

        static bool GetInputFormat(string text)
        {
            Console.Write(text);
            if (Console.ReadLine().ToLower().Contains("comma"))
                return false;
            else
                return true;
        }

        static string GetInput(string text)
        {
            string name;
            while (true)
            {
                Console.Write(text);
                name = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(name) && name.Length <= 20)
                    break;
                else
                {
                    Console.WriteLine("Prova igen! (1-20 tecken)");
                }
            }
            return name;

        }

        static int GetTimes(string text)
        {
            int times;
            while (true)
            {
                Console.Write(text);
                times = Convert.ToInt32(Console.ReadLine());
                if (times >= 0 && times <= 6)
                    break;
                else
                    Console.WriteLine("Prova igen! (0-6)");
            }

            return times;

        }

        //
        //
        //
        //
        // EXERCISE 3.1 (den om sömn)

        static void Exercise3_1()
        {

            int sleepyHours = GetSleepyHours();
            //int normalSleep = GetNormalSleep();
            //CommentOnSleepyHours(sleepyHours, normalSleep);

            // var sleepTime = GetSleepyDate();
            TimeSpan normalTime = GetNormalSleepTimeSpan();
            CommentOnSleepyHours(sleepyHours, normalTime);

        }

        static TimeSpan GetNormalSleepTimeSpan()
        {
            Console.Write("Hur många timmar brukar du sova? ");
            return GetTimeSpan(Console.ReadLine());
        }

        static TimeSpan GetTimeSpan(string time)
        {
            var timeList = new List<int>(); 

            foreach (char ch in time)
            {
                if (Char.IsNumber(ch))
                    timeList.Add(ch);
            }


            if (timeList.Count == 1) //Antar att enda siffran är en timeangivelse
            {
                int hours = timeList[0];
                return new TimeSpan(hours, 0, 0);
            }
            else if (timeList.Count == 2) //Antar att båda siffrorna är timangivelse 10+ timmar
            {
                int hours = timeList[0] * 10 + timeList[1];
                return new TimeSpan(hours, 0, 0);
            }
            else if (timeList.Count == 4) //Antar att 4 sifforr är HH:MM
            {
                int hours = timeList[0] * 10 + timeList[1];
                int minutes = timeList[2] * 60 + timeList[3];
                return new TimeSpan(hours, minutes, 0);
            }
            else
                return new TimeSpan();
        }

        static DateTime GetDateTime(string time)
        {
            return new DateTime();
        }

        static int GetNormalSleep()
        {
            Console.Write("Hur många timmar brukar du sova? ");
            return Convert.ToInt32(Console.ReadLine());

        }

        static int GetSleepyHours()
        {
            int bedtime;
            int waketime;

            Console.Write("När gick du och lade dig? ");
            bedtime = Convert.ToInt32(Console.ReadLine());

            Console.Write("När vaknade du? ");
            waketime = Convert.ToInt32(Console.ReadLine());

            return CalculateSleepyHours(bedtime, waketime);
        }

        //static TimeSpan GetSleepyDate()
        //{
        //    DateTime bedtime;
        //    DateTime waketime;
        //    TimeSpan ts = new TimeSpan();

        //    Console.Write("När gick du och lade dig? ");
        //    bedtime = GetDateTime(Console.ReadLine());

        //    Console.Write("När vaknade du? ");
        //    waketime = Convert.ToInt32(Console.ReadLine());

        //    //return CalculateSleepyHours(bedtime, waketime);
        //    return ts;
        //}



        public static int CalculateSleepyHours(int bedtime, int waketime)
        {
            return (24 - bedtime) + waketime;

        }





        public static int CalculateSleepyDate(DateTime bedtime, DateTime waketime)
        {
            return 0;
            //return (24 - bedtime) + waketime;
        }

        static void CommentOnSleepyHours(int sleepyHours, int normalSleep)
        {
            if (sleepyHours > 0 && sleepyHours <= (normalSleep - 2))
                Console.WriteLine($"Du har bara sovit {sleepyHours} timmar. Du borde gå och lägga dig igen.");
            else if (sleepyHours > (normalSleep-2) && sleepyHours <= (normalSleep +2))
                Console.WriteLine($"Godmorgon! Du har sovit {sleepyHours} timmar.");
            else if (sleepyHours > (normalSleep + 2))
                Console.WriteLine($"Vad länge du har sovit! {sleepyHours} timmar.");
            else
                Console.WriteLine($"Jag förstår inte hur du kan sova {sleepyHours} timmar.");
        }

        static void CommentOnSleepyHours(int sleepyHours, TimeSpan normalSleepTimeSpan)
        {
            int normalSleep = Convert.ToInt32(normalSleepTimeSpan.TotalHours);
            
            if (sleepyHours > 0 && sleepyHours <= (normalSleep - 2))
                Console.WriteLine($"Du har bara sovit {sleepyHours} timmar. Du borde gå och lägga dig igen.");
            else if (sleepyHours > (normalSleep - 2) && sleepyHours <= (normalSleep + 2))
                Console.WriteLine($"Godmorgon! Du har sovit {sleepyHours} timmar.");
            else if (sleepyHours > (normalSleep + 2))
                Console.WriteLine($"Vad länge du har sovit! {sleepyHours} timmar.");
            else
                Console.WriteLine($"Jag förstår inte hur du kan sova {sleepyHours} timmar.");
        }

    }

    public class ZeldaPerson
    {
        public ConsoleColor color;
        public string name;

    }


}
