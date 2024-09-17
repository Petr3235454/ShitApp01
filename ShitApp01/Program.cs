using ShitApp01.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace ShitApp01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPage page = new HomePage();
            while (true)
            {
                page.PrintInfo(); 
                var key = Console.ReadKey().Key;
                Console.Clear();
                if (key == ConsoleKey.Escape || key == ConsoleKey.NumPad5 )
                    page = page.BackPage(); 
                else
                    page = page.NextChoice(key); 
            }
        }
    }
}
