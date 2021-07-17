using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Contracts;
using WebApi.Entities;
using WebApi.Entities.Models;

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


        public Employee GetEmployee(string companyId, string id, bool trackChanges) =>
            FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackChanges)
            .SingleOrDefault();

        public IEnumerable<Employee> GetEmployees(string companyId, bool trackChanges) =>
            FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
            .OrderBy(e => e.name);
    }
}
