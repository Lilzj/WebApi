using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities.Models;

namespace WebApi.Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(string companyId, bool trackChanges);
        Task<Employee> GetEmployeeAsync(string companyId, string id, bool trackChanges);
        void AddEmployee(string companyId, Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
