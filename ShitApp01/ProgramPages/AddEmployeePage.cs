using System;
using System.Collections.Generic;
using System.Reflection;
using ShitApp01.EmployeeServices;
using ShitApp01.Interfaces;
using ShitApp01.OtherUtilities;

namespace ShitApp01.ProgramPages
{
    internal class AddEmployeePage : IPage
    {
        
        private IEmployeeManagement listEmployee;

        
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
           
        }

        public IPage NextChoice(ConsoleKey key)
        {
            Header.Logo();

            if (key == ConsoleKey.NumPad1)
            {
                Console.WriteLine("\nВыбрано добавление мужчины\n");
                listEmployee.AddEmployee("м");
            }
            else if (key == ConsoleKey.NumPad2)
            {
                Console.WriteLine("\nВыбрано добавление женщины\n");
                listEmployee.AddEmployee("ж");
            }
            else if (key == ConsoleKey.NumPad3)
            {
                BackPage();
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
            ConsoleWriter.ChooseWriter("Добавить мужчину", "Добавить женщину", "Вернуться назад");
        }
    }
}