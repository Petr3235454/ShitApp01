using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShitApp01.EmployeeServices;
using ShitApp01.Interfaces;
using ShitApp01.OtherUtilities;
using ShitApp01.ProgramPages;
namespace ShitApp01
{
    public class HomePage : IPage
    {
        
        private IEmployeeManagement listEmployee; 

        private readonly Dictionary<ConsoleKey, IPage> pages;

        public HomePage()
        {
            listEmployee = new ListEmployeeServices();

            pages = new Dictionary<ConsoleKey, IPage>()
            {
                { ConsoleKey.NumPad1, new EmployeeDisplayPage(listEmployee) },
                { ConsoleKey.NumPad2, new AddEmployeePage(listEmployee) },
            };
        }
        
        public IPage BackPage()
        {
            return this;
        }

        public void Functional()
        {
            
        }

        public IPage NextChoice(ConsoleKey key)
        {
            if (pages.ContainsKey(key))
            {
                return pages[key];
            }
            return this;
        }
        
        public void PrintInfo()
        {
            Header.Logo();
            ConsoleWriter.ChooseWriter("Просмотр сотрудников", "Добавить сотрудника", "Домашняя страница");
            
            
        }
    }
}