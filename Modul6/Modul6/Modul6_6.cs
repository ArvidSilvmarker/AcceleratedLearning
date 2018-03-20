using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Modul6
{
    class Modul6_6
    {
        public void Run()
        {
            var zippy = new ZipAddress("412 23");
            while (true)
            {
                Console.WriteLine($"The zipcode is {zippy.ZipCode}.");
                Console.Write("Enter new zipcode: ");
                string input = Console.ReadLine();
                if (input.Trim().ToLower() == "quit")
                    break;
                else
                    zippy.ZipCode = input;
            }

        }
    }

    class ZipAddress
    {
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        private string _zipCode;

        public string ZipCode
        {
            get => _zipCode;
            set => _zipCode = IsZipCode(value) ? value : _zipCode;
        }

        public void SetZipCode(string newZipCode)
        {
            if (IsZipCode(newZipCode))
                ZipCode = newZipCode;
        }

        public bool IsZipCode(string newZipCode)
        {
            bool isZipCode = true;
            if (newZipCode.Length != 6)
            {
                Console.WriteLine("Zipcode must have 6 positions.");
                return false;
            }

            for (int i = 0; i < newZipCode.Length; i++)
            {
                if (i < 3 && !Char.IsDigit(newZipCode[i]))
                {
                    Console.WriteLine("Zipcode must have digit on position 1, 2, 3.");
                    isZipCode = false;
                }
                else if (i == 3 && newZipCode[i] != ' ')
                {
                    Console.WriteLine("Zipcode must have space on 4th position.");
                    isZipCode = false;
                }
                else if (i > 3 && i < 6 && !Char.IsDigit(newZipCode[i]))
                {
                    Console.WriteLine("Zipcode must have digit on position 5 & 6.");
                    isZipCode = false;
                }
            }

            return isZipCode;
        }

        public string GetZipCode()
        {
            return ZipCode;
        }

        public string FullStreet => $"{Street} {StreetNumber}";

        public string GetFullStreet()
        {
            return $"{Street} {StreetNumber}";
        }

        public ZipAddress(string street, string streetNumber, string city, string zipCode)
        {
            Street = street;
            StreetNumber = streetNumber;
            City = city;
            SetZipCode(zipCode);
        }

        public ZipAddress(string zipCode)
        {
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
