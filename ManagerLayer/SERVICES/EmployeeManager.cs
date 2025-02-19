using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.MODEL;
using ManagerLayer.INTERFACES;
using RepositoryLayer.INTERFACES;

namespace ManagerLayer.SERVICES
{
    public  class EmployeeManager:IEmployeeManager
    {
        public readonly IEmployeeRepository empl;

        public EmployeeManager(IEmployeeRepository empl)
        {
            this.empl = empl;
        }

        public bool AddEmployee(AddEmployee employee)
        {
            return empl.AddEmployee(employee);
        }

        public List<EmployeeModel> GetAllEmployee()
        {
            return empl.GetAllEmployee();
        }

        public bool UpdateEmployee(EmployeeModel employee)
        {
            return empl.UpdateEmployee(employee);
        }

        public EmployeeModel GetEmployeeById(int? id)
            {

            return empl.GetEmployeeById(id);
        }

        public bool DeleteEmployee(int? id)
        {
            return empl.DeleteEmployee(id);
        }
    }
}
