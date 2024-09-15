using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShitApp01.Models;

namespace ShitApp01.Interfaces
{
<<<<<<< HEAD
    public interface IEmployeeManagement  // Существование этого интерфейса под вопросом 
    {                                      
        List<Employee> Employees { get; }
        void AddEmployee(string gender);
        //void ClearAllEmployees();
=======
    public interface IEmployeeManagement   // ИНТЕРФЕЙС СОЗДАН ИМЕННО ДЛЯ КЛАССА ListEmployee, с его помощью сделал List общим.
    {                                      // Класс ListEmployee сделал классом содержащим методы для манипуляций со списком и с помощью интерфейса смог использовать методы класса не создавая экземпляры этого же класса в других и прочую чепуху

        List<Employee> Employees { get; }
        void AddEmployee(string gender);
        void ClearAllEmployees();
>>>>>>> b7175beaa08b4f600d3b1af2c0388c5e050bf7bd
        void DeleteEmployeeByIndex(Employee employee);

    }
}
