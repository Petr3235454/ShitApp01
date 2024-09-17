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

        public string GetGenderSpecificInput(string gender)
        {
            if (gender == "м")
            {
                Console.WriteLine("Введите длину члена (см):\n");
                return Console.ReadLine();
            }
            else if (gender == "ж")
            {
                Console.WriteLine("Введите размер груди:\n");
                return Console.ReadLine();
            }
            return null;
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
    }
}
