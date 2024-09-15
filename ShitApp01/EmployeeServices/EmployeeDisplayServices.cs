using ShitApp01.Interfaces;
using ShitApp01.Models;
using ShitApp01.OtherUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD

namespace ShitApp01.EmployeeServices
{
    public class EmployeeDisplayServices
    {
        private readonly IEmployeeManagement listEmployee;

        public EmployeeDisplayServices(IEmployeeManagement employeeManagement)
        {

            listEmployee = employeeManagement;
        }

=======
using System.Text;
using System.Threading.Tasks;

namespace ShitApp01.EmployeeServices
{
    public class EmployeeDisplayServices 
    {
        
        private IEmployeeManagement listEmployee;
>>>>>>> b7175beaa08b4f600d3b1af2c0388c5e050bf7bd
        public void DisplayEmployeeInformation(Employee employee)
        {
            Console.Clear();
            Header.Logo();
<<<<<<< HEAD
=======

>>>>>>> b7175beaa08b4f600d3b1af2c0388c5e050bf7bd
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
<<<<<<< HEAD
            listEmployee.DeleteEmployeeByIndex(employee);

            PageCleaner.ClearAndWait("Информация о сотруднике обновлена.");
            
=======

            // Вызов метода удаления сотрудника по индексу из класса ListEmployee.cs
            listEmployee.DeleteEmployeeByIndex(employee);
>>>>>>> b7175beaa08b4f600d3b1af2c0388c5e050bf7bd
        }

        public void DisplayAllEmployees()
        {
            while (true)
            {
<<<<<<< HEAD
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

=======
                Console.Clear();
                Header.Logo();
                Console.WriteLine("ВСЕ СОТРУДНИКИ");

                // Проверяем, что список сотрудников не равен null
                if (listEmployee?.Employees == null || listEmployee.Employees.Count == 0)
                {
                    Console.WriteLine("Нет сотрудников для отображения.");
                    Console.WriteLine("Нажмите Escape для выхода.");
                    Console.ReadKey();
                    return;
                }

                for (int i = 0; i < listEmployee.Employees.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] Имя: {listEmployee.Employees[i].Name} Фамилия: {listEmployee.Employees[i].FirstName} Отчество: {listEmployee.Employees[i].LastName}");
                }

                Console.WriteLine("Введите индекс сотрудника для отображения подробной информации (или нажмите Escape для выхода):");
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    return;
                }

                if (int.TryParse(key.KeyChar.ToString(), out int index) && index > 0 && index <= listEmployee.Employees.Count)
                {
                    DisplayEmployeeInformation(listEmployee.Employees[index - 1]);
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Повторите попытку.");
                }
            }
        }


>>>>>>> b7175beaa08b4f600d3b1af2c0388c5e050bf7bd
        public void DisplayAllEmployeesByGender(string gender)
        {
            while (true)
            {
                Console.Clear();
                Header.Logo();
                Console.WriteLine($"ВСЕ СОТРУДНИКИ {gender.ToUpper()}");

<<<<<<< HEAD
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
=======
                var employeesByGender = gender == "мужчин" ?
                    listEmployee.Employees.OfType<MaleEmployee>().Cast<Employee>().ToList() :
                    listEmployee.Employees.OfType<FemaleEmployee>().Cast<Employee>().ToList();

                if (employeesByGender.Any())
                {
                    for (int i = 0; i < employeesByGender.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] Имя: {employeesByGender[i].Name} Фамилия: {employeesByGender[i].FirstName} Отчество: {employeesByGender[i].LastName}");
                    }

                    Console.WriteLine("Введите индекс сотрудника для отображения подробной информации (или нажмите Escape для выхода):");
                    var key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        return;
                    }

                    if (int.TryParse(key.KeyChar.ToString(), out int index) && index > 0 && index <= employeesByGender.Count)
                    {
                        Console.Clear();
                        DisplayEmployeeInformation(employeesByGender[index - 1]);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Некорректный ввод. Повторите попытку.");
                    }
                }
                else
                {
                    Console.Clear();
                    Header.Logo();
                    Console.WriteLine("Нет сотрудников для отображения.");
                    Console.WriteLine("Нажмите Escape для продолжения.");
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        return;
                    }
                    Console.Clear();
                }
            }
        }
>>>>>>> b7175beaa08b4f600d3b1af2c0388c5e050bf7bd
    }
}