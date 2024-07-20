using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShitApp01
{
    internal class EmployeeData
    {
        public static void SaveEmployeesToJson(List<Employee> employees)
        {
            string jsonString = JsonSerializer.Serialize(employees);
            File.WriteAllText("employees.json", jsonString);
        }

        public static List<Employee> LoadEmployeesFromJson()
        {
            string jsonString = File.ReadAllText("employees.json");
            return JsonSerializer.Deserialize<List<Employee>>(jsonString);
        }
    }
}
