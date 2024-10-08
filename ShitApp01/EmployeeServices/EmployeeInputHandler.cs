﻿using ShitApp01.Models;
using ShitApp01.OtherUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitApp01.EmployeeServices
{
    public class EmployeeInputHandler
    {
        public string GetName()
        {
            return GetValidatedInput("Имя");
        }

        public string GetFirstName()
        {
            return GetValidatedInput("Фамилия");
        }

        public string GetLastName()
        {
            return GetValidatedInput("Отчество");
        }

        public int GetSalary()
        {
            return GetValidatedSalary();
        }

        private int GetValidatedSalary()
        {
            int salary;
            while (true)
            {
                Console.WriteLine("Введите зарплату сотрудника:");
                if (int.TryParse(Console.ReadLine(), out salary) && salary > 0)
                {
                    return salary;
                }
                Console.WriteLine("Введите корректную зарплату");
            }
        }
      
        public int GetGenderSpecificInput(string gender)
        {
            while (true)
            {
                if (gender == "м")
                {
                    Console.WriteLine("Введите длину члена (см):");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int dickLength) && dickLength > 0)
                    {
                        return dickLength;
                    }
                    else
                    {
                        Console.WriteLine("Попробуйте еще раз.");
                    }
                }
                else if (gender == "ж")
                {
                    Console.WriteLine("Введите размер груди (см):");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int boobSize) && boobSize > 0)
                    {
                        return boobSize;
                    }
                    else
                    {
                        Console.WriteLine("Попробуйте еще раз.");
                    }
                }
            }
        }


        private string GetValidatedInput(string fieldName)
        {
            string input;
            while (true)
            {
                Console.WriteLine($"Введите {fieldName}:");
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && input.All(char.IsLetter))
                {
                    return input;
                }

                Console.WriteLine($"{fieldName} должно содержать только буквы. Попробуйте еще раз.");
            }
        }

        public static void HandleUserInput(ConsoleKey key, Employee employee)
        {
            ListEmployeeServices services = new ListEmployeeServices();
            switch (key)
            {
                case ConsoleKey.NumPad1:
                    services.DeleteEmployeeByIndex(employee);
                    
                    break;

                case ConsoleKey.NumPad2:
                    services.EditEmployee(employee);
                    PageCleaner.ClearAndWait("Информация о сотруднике обновлена.");
                    break;

                case ConsoleKey.Escape:
                    break;

                default:
                    Console.WriteLine("Неизвестная команда. Пожалуйста, попробуйте снова.");
                    Thread.Sleep(1000);
                    return;
            }
        }
    }
}
