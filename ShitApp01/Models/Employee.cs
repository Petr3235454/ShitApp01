using System;
using System.Text.Json.Serialization;

namespace ShitApp01.Models
{
    
    public class Employee 
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public string Gender { get; set; }

        public Employee(string name, string firstName, string lastName, int salary, string gender)
        {
            Name = name;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Gender = gender;
        }
    }
}