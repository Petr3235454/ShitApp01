using System;
using System.Collections.Generic;
using System.Linq;
using ShitApp01.Interfaces;
using ShitApp01.Models;
using ShitApp01.OtherUtilities;

namespace ShitApp01.EmployeeServices
{
    public class ListEmployeeServices
    {
        private readonly EmployeeInputHandler _inputHandler;
        public List<Employee> Employees => EmployeeStorage.Employees;

        public ListEmployeeServices()
        {
            _inputHandler = new EmployeeInputHandler();
            var loadedEmployees = EmployeeData.LoadEmployeesFromJson();
            foreach (var employee in loadedEmployees)
            {
                EmployeeStorage.AddEmployee(employee);
            }
        }

        public void AddEmployee(string gender)
        {
            string name = _inputHandler.GetName();
            string firstName = _inputHandler.GetFirstName();
            string lastName = _inputHandler.GetLastName();
            int salary = _inputHandler.GetSalary();

            Employee newEmployee;

            if (gender == "м")
            {
                string dickLength = _inputHandler.GetGenderSpecificInput(gender);
                newEmployee = new MaleEmployee(name, firstName, lastName, salary, "м", dickLength);
            }
            else if (gender == "ж")
            {
                string boobSize = _inputHandler.GetGenderSpecificInput(gender);
                newEmployee = new FemaleEmployee(name, firstName, lastName, salary, "ж", boobSize);
            }
            else
            {
                Console.WriteLine("Некорректно указан пол\n");
                return;
            }

            EmployeeStorage.AddEmployee(newEmployee);
            EmployeeData.SaveEmployeesToJson(EmployeeStorage.Employees);

            PageCleaner.ClearAndWait($"Сотрудник успешно добавлен\nКоличество сотрудников: {EmployeeStorage.Employees.Count}\n");
        }

        public static void ClearAllEmployees()
        {
            if (EmployeeStorage.Employees.Count == 0)
            {
                PageCleaner.ClearAndWait("Нет сотрудников для увольнения");
                return;
            }

            EmployeeStorage.ClearAll();
            EmployeeData.SaveEmployeesToJson(EmployeeStorage.Employees);
            PageCleaner.ClearAndWait("Все сотрудники удалены");
        }

        public void DeleteEmployeeByIndex(Employee employee)
        {
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    return;
                }
                if (key.Key == ConsoleKey.NumPad1)
                {
                    Console.WriteLine("Вы уверены, что хотите удалить этого сотрудника? (Y/N)\n");
                    var confirmationKey = Console.ReadKey(true);
                    if (confirmationKey.Key == ConsoleKey.Y)
                    {
                        EmployeeStorage.RemoveEmployee(employee);
                        Console.WriteLine("Сотрудник удален.\n");
                        Thread.Sleep(2000);
                        return;
                    }
                    else if (confirmationKey.Key == ConsoleKey.N)
                    {
                        Console.WriteLine("Удаление отменено.\n");
                        Thread.Sleep(2000);
                        return;
                    }
                }
            }
        }
    }
}

