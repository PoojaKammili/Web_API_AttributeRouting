using Microsoft.AspNetCore.Mvc;
using Web_API_AttributeRouting.Models;
    namespace Web_API_AttributeRouting.Services
{
    public class EmployeeService
    {
        static List<Employee> employees = new List<Employee>();
        static int Id = 1;
       public EmployeeService() { }
        //create
        public Employee CreateEmployee(Employee employee)
        {
            employee.Id = Id++;
            employees.Add(employee);
            return employee;

        }
        //getall
        public List<Employee> GetEmployees()
        {
            return employees;
        }
        //getbyid
        public Employee GetEmployeeById(int id)
        {
            return employees.FirstOrDefault(e=>e.Id==id);
        }
        //getbydept
        public List<Employee> GetEmployeeByDept(string department)
        {
            return employees.Where(e=>e.Department ==department).ToList();
        }
        //update
        public Employee UpdateEmployee(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }
        //delete
        public void DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
            }
        }
    }
}
