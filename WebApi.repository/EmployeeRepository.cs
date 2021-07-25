using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Contracts;
using WebApi.Entities;
using WebApi.Entities.Models;
using WebApi.Entities.Pagination;
using static WebApi.Entities.Pagination.RequestParam;

namespace WebApi.repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void AddEmployee(string companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee) => Delete(employee);

        public async Task<Employee> GetEmployeeAsync(string companyId, string id, bool trackChanges) =>
            await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<PagedList<Employee>> GetEmployeesAsync(string companyId, EmployeeParam employeeParam, bool trackChanges)
        {
            var employees = await FindByCondition(e => e.CompanyId.Equals(companyId)
              .FilterEmployees(employeeParam.MinAge, employeeParam.MaxAge)
              .OrderBy(e => e.name)
              .ToListAsync(); 

            return PagedList<Employee>
                .ToPagedList(employees, employeeParam.PageNumber, employeeParam.PageSize);
        }
          
    }
}
