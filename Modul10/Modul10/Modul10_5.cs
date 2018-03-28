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
            //Console.Write("Vill du att programmet ska skriva över produkter som redan finns? ");
            //bool replace = Console.ReadLine().Trim().ToLower().Contains("ja") ? true : false;
            var products = new Dictionary<int, Product>();
            while (true)
            {
                Console.Write("Skriv in produkt (ID, namn): ");
                string answer = Console.ReadLine();
                List<string> commands = new List<string>();

                if (answer.Trim().ToLower() == "quit" || string.IsNullOrWhiteSpace(answer))
                    break;

                if (answer.ToLower().Contains("command:"))
                    commands = GetCommand(answer);
                


                object[] array = answer.Split(',').Select(text => text.Trim()).ToArray();

                if (products.ContainsKey(Convert.ToInt32(array[0])))
                {
                    if (commands.Contains("replace"))
                        products.Remove(Convert.ToInt32(array[0]));
                    else
                    {
                        WriteError($"Produkt {array[0]} finns redan.");
                        continue;
                    }
                }

                if (commands.Contains("toupper"))
                    array[1] = array[1].ToString().ToUpper();
                if (commands.Contains("tolower"))
                    array[1] = array[1].ToString().ToLower();

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

        private void PrintFiveFirst(List<string> texts)
        {
            texts.Take(5).ToList().ForEach(text => Console.WriteLine(text));
        }


        private List<string> GetCommand(string answer)
        {
            string[] text = answer.Split(',');
            List<string> commands = text[2].Split(':',StringSplitOptions.RemoveEmptyEntries).ToList();
            commands.RemoveAt(0);
            return commands.Select(command => command.ToLower()).ToList();
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

