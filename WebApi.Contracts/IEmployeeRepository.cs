using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities.Models;
using WebApi.Entities.Pagination;
using static WebApi.Entities.Pagination.RequestParam;

namespace WebApi.Contracts
{
    public interface IEmployeeRepository
    {
        Task<PagedList<Employee>> GetEmployeesAsync(string companyId, EmployeeParam employeeParam, bool trackChanges);
        Task<Employee> GetEmployeeAsync(string companyId, string id, bool trackChanges);
        void AddEmployee(string companyId, Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
