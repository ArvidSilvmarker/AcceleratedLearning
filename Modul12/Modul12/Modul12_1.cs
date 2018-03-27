using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Modul12
{
    class Modul12_1
    {
        public void Run()
        {


            string[] rockstarsArray = new string[] { "Jim Morrison", "Ozzy Osborne", "Jo Bench", "Curt Cobain" };
            List<string> rockstarsList = new List<string> { "Freddie Mercury", "David Bowie", "Sting", "Madonna" };

            DisplayArrayOfRockStars(rockstarsArray);
            Console.WriteLine();
            DisplayListOfRockStars(rockstarsList);
            Console.WriteLine();
            DisplayRockstars(rockstarsArray);
            Console.WriteLine();
            DisplayRockstars(rockstarsList);
            Console.WriteLine();
            DisplayListOfRockStarsObjects(rockstarsList);
            Console.WriteLine();
            RemoveFirstRockStar(rockstarsArray);
            Console.WriteLine();
            RemoveFirstRockStar(rockstarsList);
        }

        private void DisplayRockstars(IEnumerable<string> rockstars)
        {
            if (rockstars.GetType() == typeof(string[]))
                DisplayArrayOfRockStars((string[])rockstars);

            else
            {
                DisplayListOfRockStars((List<string>)rockstars);
            }

            //foreach (var rockstar in rockstars)
            //{
            //    Console.WriteLine(rockstar);
            //}
        }

        private void DisplayListOfRockStars(List<string> rockstarsList)
        {

            List<string> newList = rockstarsList.FindAll(name => true).ToList();
            newList.Add("Yngwie Malmsteen");
            newList.ForEach(s => Console.WriteLine(s));
        }

        private void DisplayArrayOfRockStars(string[] rockstarsArray)
        {
            string[] array = new string[rockstarsArray.Length+1];
            array[rockstarsArray.Length] = "Yngwie Malmsteen";
            for (int i = 0; i < rockstarsArray.Length; i++)
            {
                array[i] = rockstarsArray[i];
            }
            foreach (var s in array)
            {
                Console.WriteLine(s);
            }
        }

        private void DisplayListOfRockStarsObjects(IEnumerable<object> rockstars)
        {
            foreach (var rockstar in rockstars)
            {
                Console.WriteLine(rockstar);
            }
        }

        void RemoveFirstRockStar(IEnumerable<string> rockstars)
        {
            List<string> rockstarsList;
            if (rockstars.GetType() == typeof(string[]))
            {
                string[] rockstarsArray = new string[rockstars.Count() - 1];
                for (int i = 0; i < rockstarsArray.Count(); i++)
                {
                    rockstarsArray[i] = rockstars.ElementAt(i+1);
                }
                DisplayArrayOfRockStars(rockstarsArray);
            }

            else
            {
                rockstarsList = (List<string>)rockstars;
                rockstarsList.RemoveAt(0);
                DisplayListOfRockStars(rockstarsList);
            }



        }
    }
}
