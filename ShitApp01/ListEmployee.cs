using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShitApp01
{
    public class ListEmployee : IEmployeeManagement
    {
        private IEmployeeManagement listEmployee;
        public static List<Employee> employees { get; } = new List<Employee>(); //ясно
        public List<Employee> Employees => employees; //паблик поле для манипуляций со списком, ебаный фундамент, просто сердце всего нахуй

        public readonly Dictionary<ConsoleKey, Action> actions;

        // Словарь для выбора пола при создании сотрудника
        public ListEmployee() 
        {
            actions = new Dictionary<ConsoleKey, Action>()
            {
                { ConsoleKey.NumPad1, () => AddEmployee("м")  },
                { ConsoleKey.NumPad2, () => AddEmployee("ж")  },
            };
        }

        // Создание сотрудника
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

            // actions { ConsoleKey.NumPad1, () => AddEmployee("м")  },
            if (gender == "м")
            {
                Console.WriteLine("Введите длину члена:\n");
                string dickLength = Console.ReadLine();
                employees.Add(new MaleEmployee(name, firstName, lastName, salary, "м", dickLength));
            }
            // actions { ConsoleKey.NumPad2, () => AddEmployee("ж")  },
            else if (gender == "ж")
            {
                Console.WriteLine("Введите размер груди:\n");
                string boobSize = Console.ReadLine();
                employees.Add(new FemaleEmployee(name, firstName, lastName, salary, "ж", boobSize));
            }
            else
            {
                Console.WriteLine("Некорректно указан пол\n");
                return; // Выход из метода из-за неправильной спецификации пола
            }

            Console.Clear();
            Console.WriteLine("Сотрудник успешно добавлен\n");
            Console.WriteLine("Нажмите любую клавишу для продолжения\n");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine($"Количество сотрудников: {employees.Count}\n");
        }

        public void ClearAllEmployees()
        {
            Header.Logo();
            Console.Clear();
            if (employees.Count == 0)
            {
                Header.Logo();
                Console.WriteLine("Увольнять некого!\n");
                Console.WriteLine("Нажмите любую клавишу для продолжения\n");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Header.Logo();
                employees.Clear();
                Console.WriteLine("Все нахуй уволены!\n");
                Console.WriteLine("Нажмите любую клавишу для продолжения\n");
                Console.ReadKey();
                Console.Clear();
            }
            
        }

        public void DeleteEmployeeByIndex(Employee employee)
        {
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    return;
                }
                if (key.Key == ConsoleKey.NumPad1)
                {
                    Console.WriteLine("Вы уверены, что хотите удалить этого сотрудника? (Y/N)\n");
                    var confirmationKey = Console.ReadKey(true);
                    if (confirmationKey.Key == ConsoleKey.Y)
                    {
                        employees.Remove(employee);
                        Console.WriteLine("Сотрудник удален.\n");
                        return;
                    }
                    else if (confirmationKey.Key == ConsoleKey.N)
                    {
                        Console.WriteLine("Удаление отменено.\n");
                        return;
                    }
                }
            }
        }
    }
}
