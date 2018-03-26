using System;
using System.Collections.Generic;
using System.Text;

namespace Modul10
{
    class Modul10_2
    {
        public void Run()
        {
            ThreeCates();
        }

        void ThreeNamesWithList()
        {
            List < string > names = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                names.Add(AskForName());
            }

            foreach (var name in names)
            {
                Console.WriteLine($"Name: {name}");
            }

        }

        void ThreeCates()
        {
            List<Cat> cates = new List<Cat>();
            for (int i = 0; i < 3; i++)
            {
                cates.Add(new Cat(AskForName(),AskForAnnoying(),AskForBreed()));
            }

            foreach (var cate in cates)
            {
                Console.WriteLine($"{cate.Name} is {(cate.IsAnnoying ? "an annoying" : "a not annoying")} {cate.Breed}");
            }

        }

        private Breed AskForBreed()
        {
            Console.Write("Breed? ");
            string answer = Console.ReadLine().Trim().ToLower();
            if (answer.Contains("siam"))
                return Breed.siamese;
            if (answer.Contains("aby"))
                return Breed.abyssinian;
            else
            {
                return Breed.norwegian_longhair;
            }
        }

        private bool AskForAnnoying()
        {
            Console.Write("Is annoying? ");
            return Console.ReadLine().ToLower().Contains("yes") ? true : false;
        }

        private string AskForName()
        {

            Console.Write("Write a name: ");
            return Console.ReadLine();
        }
    }

    public enum Breed
    {
        abyssinian, norwegian_longhair, siamese
    }

    public class Cat
    {
        public string Name { get; set; }
        public bool IsAnnoying { get; set; }
        public Breed Breed { get; set; }


        public Cat(string name, bool isAnnoying, Breed breed)
        {
            Name = name;
            IsAnnoying = isAnnoying;
            Breed = breed;
        }
    
    }
}
