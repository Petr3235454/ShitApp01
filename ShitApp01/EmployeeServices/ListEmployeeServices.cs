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
                int dickLength = _inputHandler.GetGenderSpecificInput(gender);
                newEmployee = new MaleEmployee(name, firstName, lastName, salary, "м", dickLength);
            }
            else if (gender == "ж")
            {
                int boobSize = _inputHandler.GetGenderSpecificInput(gender);
                newEmployee = new FemaleEmployee(name, firstName, lastName, salary, "ж", boobSize);
            }
            else
            {
                Console.WriteLine("Некорректно указан пол\n");
                return;
            }

            EmployeeStorage.AddEmployee(newEmployee);
            EmployeeData.SaveEmployeesToJson(EmployeeStorage.Employees);

            PageCleaner.ClearAndWait($"\nСотрудник успешно добавлен\nКоличество сотрудников: {EmployeeStorage.Employees.Count}\n");
        }

        public void EditEmployee(Employee employee)
        {
            
            
            Console.WriteLine("\n[Редактирование информации о сотруднике]\n");

            employee.Name = _inputHandler.GetName();
            employee.FirstName = _inputHandler.GetFirstName();
            employee.LastName = _inputHandler.GetLastName();
            employee.Salary = _inputHandler.GetSalary();

           
            if (employee is MaleEmployee maleEmployee)
            {
                maleEmployee.DickLength = _inputHandler.GetGenderSpecificInput("м");
            }
            else if (employee is FemaleEmployee femaleEmployee)
            {
                femaleEmployee.BoobSize = _inputHandler.GetGenderSpecificInput("ж");
            }

            
            EmployeeData.SaveEmployeesToJson(EmployeeStorage.Employees);

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
                    Console.WriteLine("\nВы уверены, что хотите удалить этого сотрудника? (Y/N)\n");
                    var confirmationKey = Console.ReadKey(true);
                    if (confirmationKey.Key == ConsoleKey.Y)
                    {
                        EmployeeStorage.RemoveEmployee(employee);
                        Console.WriteLine("Сотрудник удален.\n");
                        Thread.Sleep(1000);
                        return;
                    }
                    else if (confirmationKey.Key == ConsoleKey.N || confirmationKey.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("Удаление отменено.\n");
                        Thread.Sleep(1000);
                        return;
                    }
                }
            }
        }
    }
}

