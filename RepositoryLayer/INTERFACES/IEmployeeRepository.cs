using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.MODEL;

namespace RepositoryLayer.INTERFACES
{
    public interface IEmployeeRepository
    {
        public bool AddEmployee(AddEmployee employee);

        public List<EmployeeModel> GetAllEmployee();

        public bool UpdateEmployee(EmployeeModel employee);

        public EmployeeModel GetEmployeeById(int? id);

        public bool DeleteEmployee(int? id);
    }
}
