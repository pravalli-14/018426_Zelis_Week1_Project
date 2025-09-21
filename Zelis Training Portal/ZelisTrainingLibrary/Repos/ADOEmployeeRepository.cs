using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingLibrary.Models;
namespace ZelisTrainingLibrary.Repos
{
    public class ADOEmployeeRepository : IEmployeeRepository
    {
        SqlConnection con;
        SqlCommand cmd;

        public ADOEmployeeRepository()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source = (localdb)\MSSQLLocalDB; database = ZelisTrainingDB; integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        public void AddEmployee(Employee employee)
        {
            cmd.CommandText = $"insert into Employee values ({employee.EmpId},'{employee.EmpName}', '{employee.Designation}','{employee.EmpEmail}','{employee.EmpPhoneNo}')";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteEmployee(int empId)
        {
            cmd.CommandText = $"delete from Employee where EmpId = {empId}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Employee> GetAllEmployees()
        {
            cmd.CommandText = $"select * from Employee";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while ((reader.Read()))
            {
                Employee emp = new Employee();
                emp.EmpId = (int)reader["EmpId"];
                emp.EmpName = (string)reader["EmpName"];
                emp.Designation = (string)reader["Designation"];
                emp.EmpEmail = (string)reader["EmpEmail"];
                emp.EmpPhoneNo = (string)reader["EmpPhoneNo"];
                employees.Add(emp);
            }
            con.Close();
            return employees;

        }


        public Employee GetEmployeeById(int empId)
        {
            cmd.CommandText = $"select * from Employee where EmpId = {empId}";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Employee emp = new Employee();
                emp.EmpId = (int)reader["EmpId"];
                emp.EmpName = (string)reader["EmpName"];
                emp.Designation = (string)reader["Designation"];
                emp.EmpEmail = (string)reader["EmpEmail"];
                emp.EmpPhoneNo = (string)reader["EmpPhoneNo"];
                con.Close();
                return emp;
            }
            else
            {
                con.Close ();
                throw new ZelisTrainingException("No such employee Id");
            }
        }

        public void UpdateEmployee(int empId, Employee employee)
        {
            cmd.CommandText = $"update Employee set EmpName = '{employee.EmpName}', Designation = '{employee.Designation}', EmpEmail = '{employee.EmpEmail}', EmpPhoneNo ='{employee.EmpPhoneNo}' where empId = {empId}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<Employee> GetEmployeesByDesignation(string designation)
        {
            cmd.CommandText = $"select * from Employee where Designation='{designation}'";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {

                Employee employee = new Employee();
                employee.EmpId = (int)reader["EmpId"];
                employee.EmpName = (string)reader["EmpName"];
                employee.Designation = (string)reader["Designation"];
                employee.EmpEmail = (string)reader["EmpEmail"];
                employee.EmpPhoneNo = (string)reader["EmpPhoneNo"];

                employees.Add(employee);
            }
            con.Close();
            return employees;
        }
    }
}
