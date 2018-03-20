using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;

namespace Modul6
{
    class Modul6_4
    {

        public void Run()
        {
            var lisa = new Person();
            lisa.Gender = Gender.Female;
            lisa.FirstName = "Lisa";
            lisa.LastName = "Lisadotter";
            lisa.FavoriteSport = Sport.Rugby;
            lisa.Birthday = new DateTime(1980,01,01);
            Console.WriteLine(lisa.LikesToPlay(Sport.Tennis));
            Console.WriteLine(lisa.LikesToPlay(Sport.Rugby));

            foreach (var sport in Enum.GetValues(typeof(Sport)))
                Console.WriteLine(" * " +sport);

            Console.WriteLine();

            Console.Write("Enter sport: ");
            Console.WriteLine(lisa.LikesToPlay(Console.ReadLine()));

            String[] array = (string[])Enum.GetNames(typeof(Sport));
            List<string> list = array.ToList();
            list.Sort();
            foreach (var sport in list)
                Console.WriteLine(" * " + sport);

            //Sport[] array = (Sport[])Enum.GetValues(typeof(Sport));
            //List<Sport> list = array.ToList();
            //list.Sort();
            //foreach (var sport in list)
            //    Console.WriteLine(" * " + sport.ToString());

        }
    }

    enum Sport {Tennis, Rugby, Soccer, Hurling, Squash}

    enum Gender {Female,Male,Nonbinary}

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public Sport FavoriteSport { get; set; }

        public string LikesToPlay(Sport sport)
        {
            return FavoriteSport == sport ? $"{FirstName} likes to play {sport}." : $"{FirstName} doesn't like to play {sport}.";
        }

        public string LikesToPlay(string sport)
        {
            var s = (Sport)Enum.Parse(typeof(Sport), sport, true);
            return FavoriteSport == s ? $"{FirstName} likes to play {sport}." : $"{FirstName} doesn't like to play {sport}.";
        }

    }
}
