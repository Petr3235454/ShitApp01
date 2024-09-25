using System;
using System.Collections.Generic;
using ShitApp01.EmployeeServices;
using ShitApp01.Interfaces;
using ShitApp01.OtherUtilities;

namespace ShitApp01.ProgramPages
{
    internal class AddEmployeePage : IPage
    {
        ListEmployeeServices listEmployeeServices;
        public AddEmployeePage()
        {
            listEmployeeServices = new ListEmployeeServices(); 
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

            Console.Clear();

            Header.Logo(); 

            if (key == ConsoleKey.NumPad1)
            {
                Console.WriteLine("\nВыбрано добавление мужчины\n");
                listEmployeeServices.AddEmployee("м");
            }
            else if (key == ConsoleKey.NumPad2)
            {
                Console.WriteLine("\nВыбрано добавление женщины\n");
                listEmployeeServices.AddEmployee("ж");
            }
            else if (key == ConsoleKey.NumPad3)
            {

                Console.Clear();

                return BackPage();
            }
            else
            {
                PageCleaner.ClearAndWait("Неверный ввод");
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
