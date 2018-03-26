using System;
using System.Collections.Generic;
using System.Text;

namespace Modul10
{
    class Modul10_3
    {
        public void Run()
        {
            InfiniteCates();
        }
        void InfiniteCates()
        {
            List<Cat> cates = new List<Cat>();
            while (true)
            {
                string name = AskForName();
                if (name.Trim().ToLower() == "quit")
                    break;
                cates.Add(new Cat(name, AskForAnnoying(), AskForBreed()));
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


}
