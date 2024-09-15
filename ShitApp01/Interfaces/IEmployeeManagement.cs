using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShitApp01.Models;

namespace ShitApp01.Interfaces
{
    public interface IEmployeeManagement  // Существование этого интерфейса под вопросом 
    {                                      
        List<Employee> Employees { get; }
        void AddEmployee(string gender);
        //void ClearAllEmployees();
        void DeleteEmployeeByIndex(Employee employee);

    }
}
