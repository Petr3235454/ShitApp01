using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitApp01.OtherUtilities
{
    public static class ConsoleWriter
    {
        public static void ChooseWriter(params object[] choices)
        {
            for (int i = 0; i < choices.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {choices[i]}");
            }
        }
    }
}
