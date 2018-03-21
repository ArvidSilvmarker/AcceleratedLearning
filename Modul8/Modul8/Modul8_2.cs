using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Modul8
{
    class Modul8_2
    {
        public void Run()
        {

            try
            {
                Console.Write("Skriv in filnamn: ");
                string fileName = Console.ReadLine();
                Console.Write("Skriv in text: ");
                string inputText = Console.ReadLine();
                File.WriteAllText(fileName, inputText);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"Denna katalog finns inte: {e.Message}");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Du får inte skapa fil där: {e.Message}");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Fel på filen: {e.Message}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Du får inte skriva dylika tecken: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Något gick fel: {e.Message}");
            }
        }
    }

}
