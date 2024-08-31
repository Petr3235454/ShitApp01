using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;
using ShitApp01.EmployeeServices;
using ShitApp01.Interfaces;
using ShitApp01.Models;
using ShitApp01.OtherUtilities;
using ShitApp01.ProgramPages;

namespace ShitApp01.ProgramPages
{
    internal class EmployeeDisplayPage : IPage
    {
        EmployeeDisplayServices displayServices;
        // Приватное поле типа IEmployeeManagement в данном контексте служит для хранения ссылки на объект, реализующий интерфейс IEmployeeManagement.

        private IEmployeeManagement listEmployee;
  
        //В данном случае, конструктор EmployeeListPage принимает в качестве параметра объект listEmployee типа, реализующего интерфейс IEmployeeManagement.
        //чтобы установить связь между страницей и объектом управления сотрудниками. Это позволяет EmployeeListPage взаимодействовать с методами в IEmployeeManagement
        public EmployeeDisplayPage(IEmployeeManagement listEmployee)
        {
            this.listEmployee = listEmployee;
            
        }

        
        public IPage BackPage()
        {
            return new HomePage();
        }

        
        //Метод для отображения всех характеристик(полного отображения) выбранного сотрудника по индексу
        private void DisplayEmployeeInformation(Employee employee)
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

            listEmployee.DeleteEmployeeByIndex(employee); // Вызов метода удаления сотрудника по индексу из класса ListEmployee.cs

        }

        //Метод отображения всех сотрудников, отображение идёт краткое, только [индекс] и  ФИО
        public void DisplayAllEmployees()
        {
            while (true)
            {

                Console.Clear();
                Header.Logo();
                Console.WriteLine("ВСЕ СОТРУДНИКИ");
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
                //Далее при вводе индекса идёт вызов DisplayEmployeeInformation, который отображает все характеристики выбранного человека
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

        //Ну это вообще пиздец, согласен, я в инете нашёл, ахуел, очень сложно, но работает, метод деления на мужчин и женщин
        public void DisplayAllEmployeesByGender(string gender)
        {
            while (true)
            {
                Console.Clear();
                Header.Logo();
                Console.WriteLine($"ВСЕ СОТРУДНИКИ {gender.ToUpper()}");

                var employeesByGender = gender == "мужчин" ? listEmployee.Employees.OfType<MaleEmployee>().Cast<Employee>().ToList() : listEmployee.Employees.OfType<FemaleEmployee>().Cast<Employee>().ToList();

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

        public void Functional()
        {
            // Возможно, какая-то функциональность
        }


        public IPage NextChoice(ConsoleKey key)
        {
            Dictionary<ConsoleKey, Action> actions = new Dictionary<ConsoleKey, Action>
            {
                { ConsoleKey.NumPad1, () => DisplayAllEmployees() },
                { ConsoleKey.NumPad2, () => DisplayAllEmployeesByGender("мужчин") },
                { ConsoleKey.NumPad3, () => DisplayAllEmployeesByGender("женщин") },
                { ConsoleKey.NumPad4, () => listEmployee.ClearAllEmployees() },
                { ConsoleKey.NumPad5, () => BackPage() },
                { ConsoleKey.Escape,  () => BackPage() }
            };

            if (actions.ContainsKey(key))
            {
                actions[key]();
            }

            return this;
        }

        public void PrintInfo()
        {
            Header.Logo();
            ConsoleWriter.ChooseWriter("Показать всех сотрудников", "Показать всех сотрудников мужчин", "Показать всех сотрудников женщин", "Уволить всех нахуй", "Назад");

        }
    }
}