using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitApp01.OtherUtilities
{
    public class PageCleaner
    {
        public static void ClearAndWait(string message)
        {
            Console.Clear();
            Header.Logo();
            Console.WriteLine(message);
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
