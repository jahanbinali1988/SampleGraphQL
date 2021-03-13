using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleGraphQL.Web.DataAccess.Entity;

namespace SampleGraphQL.Web.DataAccess.DAO
{
    public class DepartmentRepository
    {
        private readonly SampleAppDbContext _sampleAppDbContext;

        public DepartmentRepository(SampleAppDbContext sampleAppDbContext)
        {
            _sampleAppDbContext = sampleAppDbContext;
        }

        public List<Department> GetAllDepartmentOnly()
        {
            return _sampleAppDbContext.Department.ToList();
        }

        public List<Department> GetAllDepartmentsWithEmployee()
        {
            return _sampleAppDbContext.Department
                .Include(d => d.Employees)
                .ToList();
        }

        public async Task<Department> CreateDepartment(Department department)
        {
            await _sampleAppDbContext.Department.AddAsync(department);
            await _sampleAppDbContext.SaveChangesAsync();
            return department;
        }
    }
}