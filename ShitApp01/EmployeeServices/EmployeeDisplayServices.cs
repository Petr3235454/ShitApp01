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
        private readonly IEmployeeManagement listEmployee;

        public EmployeeDisplayServices(IEmployeeManagement employeeManagement)
        {

            listEmployee = employeeManagement;
        }

        public void DisplayEmployeeInformation(Employee employee)
        {
            Console.Clear();
            Header.Logo();
            Console.WriteLine($"Имя: {employee.Name} Фамилия: {employee.FirstName} Отчество: {employee.LastName} Зарплата: {employee.Salary}");

            if (employee is MaleEmployee maleEmployee)
            {
                Console.WriteLine($"Длина полового члена: {maleEmployee.DickLength}");
            }
            else if (employee is FemaleEmployee femaleEmployee)
            {
                Console.WriteLine($"Размер груди: {femaleEmployee.BoobSize}");
            }

            ConsoleWriter.ChooseWriter("Удалить сотрудника", "Редактировать", "[Escape] для выхода");
            listEmployee.DeleteEmployeeByIndex(employee);

            PageCleaner.ClearAndWait("Информация о сотруднике обновлена.");
            
        }

        public void DisplayAllEmployees()
        {
            while (true)
            {
                Header.Logo();
                Console.WriteLine("ВСЕ СОТРУДНИКИ");

                if (!listEmployee.Employees.Any())
                {
                    PageCleaner.ClearAndWait("Нет сотрудников для отображения.\nНажмите Escape для выхода.");
                    return;
                }

                DisplayEmployeesList(listEmployee.Employees);
                int selectedIndex = GetEmployeeIndex(listEmployee.Employees.Count);

                if (selectedIndex == -1) return;
                DisplayEmployeeInformation(listEmployee.Employees[selectedIndex]);
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
                    ? listEmployee.Employees.OfType<MaleEmployee>().Cast<Employee>().ToList()
                    : listEmployee.Employees.OfType<FemaleEmployee>().Cast<Employee>().ToList();

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
            Console.WriteLine("Введите индекс сотрудника для отображения подробной информации (или нажмите Escape для выхода):");
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
                Console.WriteLine("Некорректный ввод. Повторите попытку.");
                PageCleaner.ClearAndWait("Пожалуйста, попробуйте снова.");
                return GetEmployeeIndex(employeeCount);
            }
        }
    }
}