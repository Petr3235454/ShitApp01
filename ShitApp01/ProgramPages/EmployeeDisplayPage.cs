using System;
using System.Security.Cryptography.X509Certificates;
using ShitApp01.EmployeeServices;
using ShitApp01.Interfaces;
using ShitApp01.OtherUtilities;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;

namespace ShitApp01.ProgramPages
{
    public class EmployeeDisplayPage : IPage
    {
        private readonly EmployeeDisplayServices services;

        public EmployeeDisplayPage()
        {
            services = new EmployeeDisplayServices();
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
            ConsoleWriter.ChooseWriter(
                "Показать всех сотрудников",
                "Показать сотрудников мужчин",
                "Показать сотрудников женщин",
                "Уволить всех",
                "Назад"
            );
        }
    }
}
