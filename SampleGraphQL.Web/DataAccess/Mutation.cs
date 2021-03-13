using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Subscriptions;
using SampleGraphQL.Web.DataAccess.DAO;
using SampleGraphQL.Web.DataAccess.Entity;

namespace SampleGraphQL.Web.DataAccess
{
    public class Mutation
    {
        public async Task<Department> CreateDepartment([Service] DepartmentRepository departmentRepository,
            [Service] ITopicEventSender eventSender, string departmentName)
        {
            var newDepartment = new Department
            {
                Name = departmentName
            };
            var createdDepartment = await departmentRepository.CreateDepartment(newDepartment);

            await eventSender.SendAsync("DepartmentCreated", createdDepartment);

            return createdDepartment;
        }

        public async Task<Employee> CreateEmployeeWithDepartmentId([Service] EmployeeRepository employeeRepository,
            string name, int age, string email, int departmentId)
        {
            Employee newEmployee = new Employee
            {
                Name = name,
                Age = age,
                Email = email,
                DepartmentId = departmentId
            };

            var createdEmployee = await employeeRepository.CreateEmployee(newEmployee);
            return createdEmployee;
        }

        public async Task<Employee> CreateEmployeeWithDepartment([Service] EmployeeRepository employeeRepository,
            string name, int age, string email, string departmentName)
        {
            Employee newEmployee = new Employee
            {
                Name = name,
                Age = age,
                Email = email,
                Department = new Department { Name = departmentName }
            };

            var createdEmployee = await employeeRepository.CreateEmployee(newEmployee);
            return createdEmployee;
        }
    }
}
