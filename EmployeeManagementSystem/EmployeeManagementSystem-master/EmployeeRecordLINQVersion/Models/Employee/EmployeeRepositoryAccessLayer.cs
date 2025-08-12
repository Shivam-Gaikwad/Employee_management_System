using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecordLINQVersion.Models.Employee
{
    public class EmployeeRepositoryAccessLayer
    {
        private List<Employee> _employeesList;
        public EmployeeRepositoryAccessLayer()
        {
             _employeesList = new List<Employee>()
             {
                new Employee(){ID = 1, Name="Atolagbe Muiz", City="Lagos", Department="IT", Gender="Male"},
                new Employee(){ID = 2, Name="Atolagbe Maryam", City="Lagos", Department="Agric", Gender="Female"},
                new Employee(){ID = 3, Name="Atolagbe Jamiu", City="Lagos", Department="IT", Gender="Male"}
             };
        }
        public List<Employee> AddEmployee(Employee employee)
        {
            employee.ID = _employeesList.Max(x => x.ID) + 1;
            _employeesList.Add(employee);
            return _employeesList;
        }

        public IEnumerable<Employee> getAllEmployees()
        {
            return _employeesList;
        }
    }
}
