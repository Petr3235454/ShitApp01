using System;

namespace ShitApp01
{
    // Ну тут я думаю понятно более менее
    public class Employee // Базовый 
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

    public class MaleEmployee : Employee // Наследник Мужской пол
    {
        public string DickLength { get; set; }

        public MaleEmployee(string name, string firstName, string lastName, int salary, string gender, string dickLength)
            : base(name, firstName, lastName, salary, gender)  // наследуются свойства базового
        {
            DickLength = dickLength; //специфические поля конкретно для сотрудников мужского пола
        }
    }

    public class FemaleEmployee : Employee // Наследник Женский пол. Тут тоже самое
    {
        public string BoobSize { get; set; }

        public FemaleEmployee(string name, string firstName, string lastName, int salary, string gender, string boobSize)
            : base(name, firstName, lastName, salary, gender)
        {
            BoobSize = boobSize;
        }
    }
}