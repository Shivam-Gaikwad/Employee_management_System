using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecordLINQVersion.Models.Employee
{
    public class EmployeeSQLRepositoryLayer : IEmployeeInterface
    {
        private readonly EmployeeDBContext _context;

        public EmployeeSQLRepositoryLayer(EmployeeDBContext context)
        {
            this._context = context;
        }
        public Employee AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployeeDetails(int? id)
        {
            Employee employee = _context.Employees.Find(id);
            if(employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> getAllEmployees()
        {
            return _context.Employees;
        }

        public Employee GetEmployeeDetails(int? id)
        {
           Employee employee = _context.Employees.Find(id);
            //if (employee != null)
            //{
            //    return employee;
            //}\
            return employee;
        }

        public Employee UpdateEmployee(Employee employeeChanges)
        {
            var employee =_context.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return employeeChanges;
        }
    }
}
