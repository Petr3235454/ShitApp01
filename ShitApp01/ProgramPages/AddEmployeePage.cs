﻿using System;
using System.Collections.Generic;
using System.Reflection;
using ShitApp01.EmployeeServices;
using ShitApp01.Interfaces;
using ShitApp01.OtherUtilities;

namespace ShitApp01.ProgramPages
{
    internal class AddEmployeePage : IPage
    {
<<<<<<< HEAD
        
        private IEmployeeManagement listEmployee;

        
=======
        // Приватное поле типа IEmployeeManagement в данном контексте служит для хранения ссылки на объект, реализующий интерфейс IEmployeeManagement.
        private IEmployeeManagement listEmployee;

        //В данном случае, конструктор AddEmployeePage принимает в качестве параметра объект listEmployee типа, реализующего интерфейс IEmployeeManagement.
        //чтобы установить связь между страницей и объектом управления сотрудниками. Это позволяет AddEmployeePage взаимодействовать с методами в IEmployeeManagement
>>>>>>> b7175beaa08b4f600d3b1af2c0388c5e050bf7bd
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
<<<<<<< HEAD
           
=======
            //У меня никак не получилось реализовать нормально, получается большая вложенность методов в Functional, ввиду чего ничего не работает, так же куча проблем вылезает с вызовами методов в других классах
>>>>>>> b7175beaa08b4f600d3b1af2c0388c5e050bf7bd
        }

        public IPage NextChoice(ConsoleKey key)
        {
<<<<<<< HEAD
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
=======
            Dictionary<ConsoleKey, Action> actions = new Dictionary<ConsoleKey, Action>   // Все NextChoise сделал в виде словарей, красиво, компактно, заебись
            {
                { ConsoleKey.NumPad1, () => { Header.Logo(); Console.WriteLine("\nВыбрано добавление мужчины\n"); listEmployee.AddEmployee("м"); } },
                { ConsoleKey.NumPad2, () => { Header.Logo(); Console.WriteLine("\nВыбрано добавление женщины\n"); listEmployee.AddEmployee("ж"); } },
                { ConsoleKey.NumPad3, () => { BackPage(); } }
            };

            if (actions.ContainsKey(key))
            {
                actions[key]();
>>>>>>> b7175beaa08b4f600d3b1af2c0388c5e050bf7bd
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