using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Modul11
{
    class Modul11_2
    {
        public delegate string Nöff(string str);
        public void Run()
        {
            var parser = new CustomerParser();
            List<Customer> list = parser.CreateListOfCustomers("PersonShort.csv");

            PrintList(list);
            Console.WriteLine();
            PrintList(list.OrderBy(customer => customer.FirstName).ToList());
            Console.WriteLine();
            PrintList(list.OrderBy(customer => customer.Age).ToList());
            Console.WriteLine();
            PrintList(list.Where(customer => customer.Age > 35).Where(customer => customer.Gender == Gender.Male).ToList());
            Console.WriteLine();
            list.Where(customer => customer.Age > 35)
                .Where(customer => customer.Gender == Gender.Male).ToList()
                .ForEach(c => Console.WriteLine($"{c.FirstName.ToUpper(),-15}{c.Age + 1000,-10}{c.Gender,-10}"));

            
        }


        public void PrintList(List<Customer> list)
        {
            list.ForEach(c => Console.WriteLine($"{c.FirstName,-15}{c.Age,-10}{c.Gender,-10}"));
            
        }
    }


    public class CustomerParser
    {
        public string Path { get; set; }

        public CustomerParser(string path)
        {
            Path = path;
        }

        public CustomerParser()
        {
            Path = @"c:\temp\";
        }


        public List<Customer> CreateListOfCustomers(string filename)
        {
            string[] lineArray = File.ReadAllLines(Path + filename);
            List<string[]> listArray = new List<string[]>();
            foreach (string line in lineArray)
                listArray.Add(line.Split(',', StringSplitOptions.RemoveEmptyEntries));

            listArray.RemoveAt(0);
            return listArray.Select(line => new Customer(line[1], line[2], (Gender) Enum.Parse(typeof(Gender), line[4]),
                Convert.ToInt32(line[5]))).ToList();
        }


    }

    public enum Gender
    {
        Female, Male
    }

    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }

        public Customer(string firstName, string lastName, Gender gender, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Age = age;
        }
        
    }
}