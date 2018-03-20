using System;
using System.Collections.Generic;
using System.Text;

namespace Modul6
{
    class Modul6_5
    {
        public void Run()
        {
            var home = new Address("Doktor Liborius gata","3","Göteborg",41223);
            home.WriteAddress();

            Console.WriteLine(home.FullStreet);
        }
    }


    class Address
    {
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }

        public string FullStreet => $"{Street} {StreetNumber}";

        public string GetFullStreet()
        {
            return $"{Street} {StreetNumber}";
        }

        public Address(string street, string streetNumber, string city, int zipCode)
        {
            Street = street;
            StreetNumber = streetNumber;
            City = city;
            ZipCode = zipCode;
        }

        public void WriteAddress()
        {
            Console.WriteLine($"Street:             {Street}");
            Console.WriteLine($"Streetnumer:        {StreetNumber}");
            Console.WriteLine($"City:               {City}");
            Console.WriteLine($"Zipcode:            {ZipCode}");
            Console.WriteLine($"Fullstreet:         {FullStreet}");
        }
    }
}
