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

                    var employees = JsonSerializer.Deserialize<List<JsonEmployee>>(jsonList);
                    return MapJsonEmployeesToConcreteEmployees(employees);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
            }
            return new List<Employee>();
        }

        private class JsonEmployee
        {
            public string Name { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Salary { get; set; }
            public string Gender { get; set; }
            public int DickLength { get; set; }
            public int BoobSize { get; set; }
        }

        private static List<Employee> MapJsonEmployeesToConcreteEmployees(List<JsonEmployee> jsonEmployees)
        {
            var employees = new List<Employee>();

            foreach (var jsonEmployee in jsonEmployees)
            {
                if (jsonEmployee.Gender == "м")
                {
                    employees.Add(new MaleEmployee(
                        jsonEmployee.Name,
                        jsonEmployee.FirstName,
                        jsonEmployee.LastName,
                        jsonEmployee.Salary,
                        jsonEmployee.Gender,
                        jsonEmployee.DickLength));
                }
                else if (jsonEmployee.Gender == "ж")
                {
                    employees.Add(new FemaleEmployee(
                        jsonEmployee.Name,
                        jsonEmployee.FirstName,
                        jsonEmployee.LastName,
                        jsonEmployee.Salary,
                        jsonEmployee.Gender,
                        jsonEmployee.BoobSize));
                }
            }
            return employees;
        }
    }
}