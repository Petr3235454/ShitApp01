using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
using ShitApp01.Interfaces;
using ShitApp01.Models;
using ShitApp01.OtherUtilities;
using Newtonsoft.Json;
using System.IO;
=======
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ShitApp01.Interfaces;
using ShitApp01.Models;
using ShitApp01.OtherUtilities;
using static System.Runtime.InteropServices.JavaScript.JSType;
>>>>>>> b7175beaa08b4f600d3b1af2c0388c5e050bf7bd

namespace ShitApp01.EmployeeServices
{
    public class ListEmployeeServices : IEmployeeManagement
    {
<<<<<<< HEAD
        public List<Employee> Employees => EmployeeStorage.Employees;
=======
        public static List<Employee> employees { get; } = new List<Employee>(); //ясно
        public List<Employee> Employees => employees; //паблик поле для манипуляций со списком, ебаный фундамент, просто сердце всего нахуй

        public readonly Dictionary<ConsoleKey, Action> actions;

        // Словарь для выбора пола при создании сотрудника
>>>>>>> b7175beaa08b4f600d3b1af2c0388c5e050bf7bd
        public ListEmployeeServices()
        {
            var loadedEmployees = EmployeeData.LoadEmployeesFromJson();
            foreach (var employee in loadedEmployees)
            {
                EmployeeStorage.AddEmployee(employee);
            }
        }
        public void AddEmployee(string gender)
        {
            Console.WriteLine("Введите имя сотрудника:\n");
            string name = Console.ReadLine();
            Console.WriteLine("Введите фамилию сотрудника:\n");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введите отчество сотрудника:\n");
            string lastName = Console.ReadLine();

            int salary;
            while (true)
            {
                Console.WriteLine("Введите зарплату сотрудника:\n");
                if (int.TryParse(Console.ReadLine(), out salary))
                {
                    break;
                }
                Console.Clear();
                Console.WriteLine("Введите корректную зарплату\n");
            }

            if (gender == "м")
            {
                Console.WriteLine("Введите длину члена (см):\n");
                string dickLength = Console.ReadLine();
<<<<<<< HEAD
                EmployeeStorage.AddEmployee(new MaleEmployee(name, firstName, lastName, salary, "м", dickLength));
=======
                employees.Add(new MaleEmployee(name, firstName, lastName, salary, "м", dickLength));


>>>>>>> b7175beaa08b4f600d3b1af2c0388c5e050bf7bd
            }
            else if (gender == "ж")
            {
                Console.WriteLine("Введите размер груди:\n");
                string boobSize = Console.ReadLine();
<<<<<<< HEAD
                EmployeeStorage.AddEmployee(new FemaleEmployee(name, firstName, lastName, salary, "ж", boobSize));
=======
                employees.Add(new FemaleEmployee(name, firstName, lastName, salary, "ж", boobSize));
                

>>>>>>> b7175beaa08b4f600d3b1af2c0388c5e050bf7bd
            }
            else
            {
                Console.WriteLine("Некорректно указан пол\n");
                return;
            }
            EmployeeData.SaveEmployeesToJson(EmployeeStorage.Employees);
            Console.Clear();
            Console.WriteLine("Сотрудник успешно добавлен\n");
            Console.WriteLine($"Количество сотрудников: {EmployeeStorage.Employees.Count}\n");
        }

        public static void ClearAllEmployees()
        {
            if (EmployeeStorage.Employees.Count == 0)
            {
                PageCleaner.ClearAndWait("Нет сотрудников для увольнения");
                return;
            }
<<<<<<< HEAD
            EmployeeStorage.ClearAll();
            EmployeeData.SaveEmployeesToJson(EmployeeStorage.Employees);
            PageCleaner.ClearAndWait("Все сотрудники удалены");
=======
            else
            {
                Header.Logo();
                employees.Clear();
                Console.WriteLine("Все нахуй уволены!\n");
                Console.WriteLine("Нажмите любую клавишу для продолжения\n");
                Console.ReadKey();
                Console.Clear();
            }

>>>>>>> b7175beaa08b4f600d3b1af2c0388c5e050bf7bd
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
