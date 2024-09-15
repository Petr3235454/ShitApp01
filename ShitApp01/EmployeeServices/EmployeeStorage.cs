using System;
using System.Collections.Generic;
using ShitApp01.EmployeeServices;
using ShitApp01.Models;

namespace ShitApp01
{
    public static class EmployeeStorage
    {
        private static readonly List<Employee> employees = new List<Employee>();

        public static List<Employee> Employees => employees;

        public static void AddEmployee(Employee employee)
        {
            employees.Add(employee);
            EmployeeData.SaveEmployeesToJson(EmployeeStorage.Employees);
        }

        public static void RemoveEmployee(Employee employee)
        {
            employees.Remove(employee);
            EmployeeData.SaveEmployeesToJson(EmployeeStorage.Employees);
        }

        public static void ClearAll()
        {
            employees.Clear();
            EmployeeData.SaveEmployeesToJson(EmployeeStorage.Employees);
        }
    }
}
