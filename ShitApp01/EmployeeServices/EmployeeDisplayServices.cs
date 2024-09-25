using ShitApp01.Interfaces;
using ShitApp01.Models;
using ShitApp01.OtherUtilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShitApp01.EmployeeServices
{
    public class EmployeeDisplayServices
    {
        public EmployeeDisplayServices() { }

        public void DisplayEmployeeInformation(Employee employee)
        {
            Console.Clear();
            Header.Logo();

            Console.WriteLine($"\nИмя: {employee.Name} \nФамилия: {employee.FirstName} \nОтчество: {employee.LastName} \nЗарплата: {employee.Salary}");

            if (employee is MaleEmployee maleEmployee)
            {
                Console.WriteLine($"Длина полового члена: {maleEmployee.DickLength}\n");
            }
            else if (employee is FemaleEmployee femaleEmployee)
            {
                Console.WriteLine($"\nРазмер груди: {femaleEmployee.BoobSize}\n");
            }

            ConsoleWriter.ChooseWriter("Удалить сотрудника", "Редактировать", "[Escape] для выхода");

            var inputHandler = new EmployeeInputHandler();
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            EmployeeInputHandler.HandleUserInput(keyInfo.Key, employee);

        }

        public void DisplayAllEmployees()
        {
            while (true)
            {
                Console.Clear();
                Header.Logo();
                Console.WriteLine("\nВСЕ СОТРУДНИКИ\n");

                if (!EmployeeStorage.Employees.Any())
                {
                    PageCleaner.ClearAndWait("Нет сотрудников для отображения.\nНажмите Escape для выхода.");
                    return;
                }

                DisplayEmployeesList(EmployeeStorage.Employees);
                int selectedIndex = GetEmployeeIndex(EmployeeStorage.Employees.Count);

                if (selectedIndex == -1) return;
                DisplayEmployeeInformation(EmployeeStorage.Employees[selectedIndex]);
            }
        }

        public void DisplayAllEmployeesByGender(string gender)
        {
            while (true)
            {
                Console.Clear();
                Header.Logo();
                Console.WriteLine($"ВСЕ СОТРУДНИКИ {gender.ToUpper()}");

                var employeesByGender = gender == "мужчин"
                    ? EmployeeStorage.Employees.OfType<MaleEmployee>().Cast<Employee>().ToList()
                    : EmployeeStorage.Employees.OfType<FemaleEmployee>().Cast<Employee>().ToList();

                if (employeesByGender.Any())
                {
                    DisplayEmployeesList(employeesByGender);
                    int selectedIndex = GetEmployeeIndex(employeesByGender.Count);

                    if (selectedIndex == -1) return;
                    DisplayEmployeeInformation(employeesByGender[selectedIndex]);
                }
                else
                {
                    PageCleaner.ClearAndWait("Нет сотрудников для отображения.\nНажмите Escape для продолжения.");
                    return;
                }
            }
        }

        private void DisplayEmployeesList(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] Имя: {employees[i].Name} Фамилия: {employees[i].FirstName} Отчество: {employees[i].LastName}");
            }
        }

        private int GetEmployeeIndex(int employeeCount)
        {

            Console.WriteLine("\nВведите индекс сотрудника для отображения подробной информации (или нажмите Escape для выхода):");

            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
            {
                return -1;
            }

            if (int.TryParse(key.KeyChar.ToString(), out int index) && index > 0 && index <= employeeCount)
            {
                return index - 1;
            }
            else
            {
                PageCleaner.ClearAndWait("Некорректный ввод. Пожалуйста, попробуйте снова.");
                DisplayAllEmployees();
                return GetEmployeeIndex(employeeCount);
            }
        }
    }
}