using ShitApp01;
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
                page.PrintInfo(); // Показываем информацию перед вводом пользователя
                var key = Console.ReadKey().Key;
                Console.Clear();
                if (key == ConsoleKey.Escape || key == ConsoleKey.NumPad5 || key == ConsoleKey.NumPad3)
                    page = page.BackPage(); // При нажатии Escape - возврат на предыдущую страницу
                else
                    page = page.NextChoice(key); // Обработка ввода пользователя
            }
        }
    }
}
