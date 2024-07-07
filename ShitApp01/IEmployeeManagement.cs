using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitApp01
{
    public interface IEmployeeManagement   // ИНТЕРФЕЙС СОЗДАН ИМЕННО ДЛЯ КЛАССА ListEmployee, с его помощью сделал List общим.
    {                                      // Класс ListEmployee сделал классом содержащим методы для манипуляций со списком и с помощью интерфейса смог использовать методы класса не создавая экземпляры этого же класса в других и прочую чепуху
                           
        List<Employee> Employees { get; }  
        void AddEmployee(string gender);
        void ClearAllEmployees();
        void DeleteEmployeeByIndex(Employee employee);

    }
}
