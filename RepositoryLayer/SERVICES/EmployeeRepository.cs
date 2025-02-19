using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CommonLayer.MODEL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.INTERFACES;

namespace RepositoryLayer.SERVICES
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DBConnection");

        }
        public bool AddEmployee(AddEmployee employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spAddEmployee", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@City", employee.City);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    cmd.Parameters.AddWithValue("@Designation", employee.Designation);

                    connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        public List<EmployeeModel> GetAllEmployee()
        {

            List<EmployeeModel> lstemployee = new List<EmployeeModel>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    EmployeeModel employee = new EmployeeModel();

                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.Email = rdr["Email"].ToString();
                    employee.Designation = rdr["Designation"].ToString();

                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }

        public bool UpdateEmployee(EmployeeModel employee)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", employee.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@City", employee.City);
                cmd.Parameters.AddWithValue("@Department", employee.Department);

                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Designation", employee.Designation);



                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
        }

        public EmployeeModel GetEmployeeById(int? id)
        {
            EmployeeModel employee = new EmployeeModel();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeID= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeID"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.City = rdr["City"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.Email = rdr["Email"].ToString();
                    employee.Designation = rdr["Designation"].ToString();


                }
            }
            return employee;
        }

        public bool DeleteEmployee(int? id)
        {

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", id);

                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result != 0)
                {
                    return true;
                }
                return true;
            }

        }


    }
}
