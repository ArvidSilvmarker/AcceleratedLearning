using System;
using System.Collections.Generic;
using System.Text;

namespace Modul5
{
    class Animal
    {
        public string Name { get; set; }
        public int Legs { get; set; }

        public Animal(string name, int numberOfLegs)
        {
            Name = name;
            Legs = numberOfLegs;
        }

        public void cutOfLegs()
        {
            Legs = 1;
            Name = "Enbenta " + Name;
        }

        public string DisplayAnimal()
        {
            return ($"Animal=({Name},{Legs})");
        }
    }
}
