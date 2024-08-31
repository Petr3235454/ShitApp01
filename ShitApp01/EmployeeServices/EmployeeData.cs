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
}
