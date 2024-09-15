using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ShitApp01.Models;
using System.IO;

namespace ShitApp01.EmployeeServices
{
<<<<<<< HEAD
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
=======
   internal class EmployeeData
   {

       void SEX() { }






       public static void SaveEmployeesToJson(List<Employee> employees)
       {
           string jsonList = JsonSerializer.Serialize(employees);
           File.WriteAllText("employees.json", jsonList);
       }

       public static List<Employee> LoadEmployeesFromJson()
       {
           string jsonList = File.ReadAllText("employees.json");
           return JsonSerializer.Deserialize<List<Employee>>(jsonList);

       }
   }
>>>>>>> b7175beaa08b4f600d3b1af2c0388c5e050bf7bd
}
