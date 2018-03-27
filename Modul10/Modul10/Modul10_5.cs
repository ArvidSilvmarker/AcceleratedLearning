using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Modul10
{
    class Modul10_5
    {
        public void Run()
        {
            ADicMove();
        }

        private void ADicMove()
        {
            Console.Write("Vill du att programmet ska skriva över produkter som redan finns? ");
            bool replace = Console.ReadLine().Trim().ToLower().Contains("ja") ? true : false;
            var products = new Dictionary<int, Product>();
            while (true)
            {
                Console.Write("Skriv in produkt (ID, namn, finns i lager (ja/nej), Butik(Inga, En, Många): ");
                string answer = Console.ReadLine();
                if (answer.Trim().ToLower() == "quit" || string.IsNullOrWhiteSpace(answer))
                    break;
                object[] array = answer.Split(',').Select(text => text.Trim()).ToArray();

                int id = Convert.ToInt32(array[0]);
                bool k = products.ContainsKey(id);
                bool c = replace;



                if (products.ContainsKey(Convert.ToInt32(array[0])))
                {
                    if (replace)
                        products.Remove(Convert.ToInt32(array[0]));
                    else
                    {
                        WriteError($"Produkt {array[0]} finns redan.");
                        continue;
                    }
                }

                try
                {
                    products = AddProduct(products, array);
                }
                catch (Exception e)
                {
                    WriteError($"Invalid product.");
                }
                
                    
            }


            PrintDic(products);


        }

        private void PrintDic(Dictionary<int, Product> dic)
        {
            Console.WriteLine();
            foreach (var a in dic)
            {
                Console.WriteLine($"ProduktID: {a.Key} heter {a.Value.Name}. ");
            }
        }

        public void WriteError(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public Dictionary<int, Product> AddProduct(Dictionary<int, Product> dic, object[] array)
        {
            try
            {
                dic.Add(Convert.ToInt32(array[0]),
                    new Product(array[1].ToString()));

            }
            catch (Exception e)
            {
                throw e;
            }

            return dic;
        }

    }

    public enum Store
    {
        INGA, EN, MÅNGA
    }

    public class Product
    {
        public string Name { get; set; }
        public bool InStock { get; set; }
        public Store Stores { get; set; }

        public Product(string name)
        {
            Name = name;
        }

        public Product(string name, bool inStock, Store stores)
        {
            this.Name = name;
            this.InStock = inStock;
            this.Stores = stores;
        }
    }
}

