using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitApp01
{
    public class HomePage : IPage
    {
        // Приватное поле типа IEmployeeManagement в данном контексте служит для хранения ссылки на объект, реализующий интерфейс IEmployeeManagement.
        //Собственно если не создавать это поле, то словарь не работает абсолютно, любые правки в конструкторах классов ломают Dictionary pages с ошибкой нужен аргумент соответствующий параметру, ну логично
        
        private IEmployeeManagement listEmployee; 

        private readonly Dictionary<ConsoleKey, IPage> pages;

        public HomePage()
        {
            listEmployee = new ListEmployee();

            pages = new Dictionary<ConsoleKey, IPage>()
            {
                { ConsoleKey.NumPad1, new EmployeeListPage(listEmployee) },
                { ConsoleKey.NumPad2, new AddEmployeePage(listEmployee) },
            };
        }
        
        public IPage BackPage()
        {
            return this;
        }

        public void Functional()
        {
            // Логика функции Functional
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
            Console.Clear();
            Header.Logo();
            Console.WriteLine(" Домашняя страница ");
            Console.WriteLine("[1] Список пользователей");
            Console.WriteLine("[2] Добавить сотрудника");
        }
    }
}