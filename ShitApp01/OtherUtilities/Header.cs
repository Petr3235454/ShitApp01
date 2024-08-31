using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitApp01.OtherUtilities
{
    // Пример заголовка с логотипом
    public class Header
    {
        public static void Logo()
        {
            Console.WriteLine(@"
  ____      _              _              ____                             _                
 |  _ \ ___| |_ _ __ _   _| |__   __ _   / ___| _____   ___ __   ___      / \   _ __  _ __  
 | |_) / _ \ __| '__| | | | '_ \ / _` | | |  _ / _ \ \ / / '_ \ / _ \    / _ \ | '_ \| '_ \ 
 |  __/  __/ |_| |  | |_| | | | | (_| | | |_| | (_) \ V /| | | | (_) |  / ___ \| |_) | |_) |
 |_|   \___|\__|_|   \__,_|_| |_|\__,_|  \____|\___/ \_/ |_| |_|\___/  /_/   \_\ .__/| .__/ 
                                                                               |_|   |_| ");
        }
    }
}