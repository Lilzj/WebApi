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
        IEnumerable<Employee> GetEmployees(string companyId, bool trackChanges);
        Employee GetEmployee(string companyId, string id, bool trackChanges);
    }
}
