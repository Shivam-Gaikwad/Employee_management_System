using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecordLINQVersion.Models.Employee
{
    public interface IEmployeeInterface
    {
        Employee AddEmployee(Employee employee);

        IEnumerable<Employee> getAllEmployees();

        Employee UpdateEmployee(Employee employee);

        Employee GetEmployeeDetails(int? id);

        Employee DeleteEmployeeDetails(int? id);



    }
}
