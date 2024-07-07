using System;
using System.Collections.Generic;
using System.Reflection;

namespace ShitApp01
{
    internal class AddEmployeePage : IPage
    {
        // Приватное поле типа IEmployeeManagement в данном контексте служит для хранения ссылки на объект, реализующий интерфейс IEmployeeManagement.
        private IEmployeeManagement listEmployee;

        //В данном случае, конструктор AddEmployeePage принимает в качестве параметра объект listEmployee типа, реализующего интерфейс IEmployeeManagement.
        //чтобы установить связь между страницей и объектом управления сотрудниками. Это позволяет AddEmployeePage взаимодействовать с методами в IEmployeeManagement
        public AddEmployeePage(IEmployeeManagement listEmployee) 
        {
            this.listEmployee = listEmployee; 
        }

        public IPage BackPage()
        {
            return new HomePage();
        }

        public void Functional()
        {
            //У меня никак не получилось реализовать нормально, получается большая вложенность методов в Functional, ввиду чего ничего не работает, так же куча проблем вылезает с вызовами методов в других классах
        }

        public IPage NextChoice(ConsoleKey key)
        {
            Dictionary<ConsoleKey, Action> actions = new Dictionary<ConsoleKey, Action>   // Все NextChoise сделал в виде словарей, красиво, компактно, заебись
            {
                { ConsoleKey.NumPad1, () => { Header.Logo(); Console.WriteLine("\nВыбрано добавление мужчины\n"); listEmployee.AddEmployee("м"); } },
                { ConsoleKey.NumPad2, () => { Header.Logo(); Console.WriteLine("\nВыбрано добавление женщины\n"); listEmployee.AddEmployee("ж"); } },
                { ConsoleKey.NumPad3, () => { BackPage(); } }
            };

            if (actions.ContainsKey(key))
            {
                actions[key]();
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }

            return this;
        }

        public void PrintInfo()
        {
            Header.Logo();
            Console.WriteLine("[1] Добавить сотрудника мужчину ");
            Console.WriteLine("[2] Добавить сотрудника женщину ");
            Console.WriteLine("[3] Вернуться назад ");
        }
    }
}