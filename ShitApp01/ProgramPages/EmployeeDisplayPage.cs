using System;
using System.Security.Cryptography.X509Certificates;
using ShitApp01.EmployeeServices;
using ShitApp01.Interfaces;
using ShitApp01.OtherUtilities;

namespace ShitApp01.ProgramPages
{
    internal class EmployeeDisplayPage : IPage
    {
        private readonly EmployeeDisplayServices services;

        public EmployeeDisplayPage(IEmployeeManagement listEmployee)
        {
            services = new EmployeeDisplayServices(listEmployee);
        }

        public IPage BackPage()
        {
            return new HomePage();
        }

        public void Functional()
        {
            // Возможно, какая-то функциональность
        }

        public IPage NextChoice(ConsoleKey key)
        {
            
            if (key == ConsoleKey.NumPad1)
            {
                services.DisplayAllEmployees();
                Console.Clear();
            }
            else if (key == ConsoleKey.NumPad2)
            {
                services.DisplayAllEmployeesByGender("мужчин");
                Console.Clear();
            }
            else if (key == ConsoleKey.NumPad3)
            { 
                services.DisplayAllEmployeesByGender("женщин");
                Console.Clear();
            }
            else if (key == ConsoleKey.NumPad4)
            {
                ListEmployeeServices.ClearAllEmployees();
            }

            return this; 
        }

        public void PrintInfo()
        {
            Header.Logo();
            ConsoleWriter.ChooseWriter("Показать всех сотрудников", "Показать сотрудников мужчин", "Показать сотрудников женщин", "Уволить всех", "Назад");
        }
    }
}
