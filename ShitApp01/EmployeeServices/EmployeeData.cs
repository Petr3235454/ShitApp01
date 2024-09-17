using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using ShitApp01.Models;

namespace ShitApp01.EmployeeServices
{
    internal class EmployeeData
    {
        
        public static void SaveEmployeesToJson(List<Employee> employees)
        {
            string jsonList = JsonSerializer.Serialize(employees);
            File.WriteAllText("employees.json", jsonList);
        }

        public static List<Employee> LoadEmployeesFromJson()
        {
            try
            {
                if (File.Exists("employees.json"))
                {
                    string jsonList = File.ReadAllText("employees.json");
                    return JsonSerializer.Deserialize<List<Employee>>(jsonList) ?? new List<Employee>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
            }
            return new List<Employee>();
        }
    }
}
