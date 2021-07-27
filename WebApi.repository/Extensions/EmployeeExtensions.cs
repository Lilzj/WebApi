using System.Linq;
using System.Linq.Dynamic.Core;
using WebApi.Entities.Models;
using WebApi.repository.Extensions.Utility;

namespace WebApi.repository.Extension
{
    public static class EmployeeExtensions
    {
        public static IQueryable<Employee> FilterEmployees(this IQueryable<Employee> employees, uint minAge,
            uint maxAge) =>
            employees.Where(e => (e.Age >= minAge && e.Age <= maxAge));

        public static IQueryable<Employee> Search(this IQueryable<Employee> employees, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return employees;

            return employees.Where(e => e.name.ToLower().Contains(searchTerm.Trim().ToLower()));
        }

        public static IQueryable<Employee> Sort(this IQueryable<Employee> employees, string QueryString)
        {
            if (string.IsNullOrWhiteSpace(QueryString))
                return employees.OrderBy(e => e.name);

            var orderQuery = QueryBuilder.CreateOrderQuery<Employee>(QueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return employees.OrderBy(e => e.name);

            return employees.OrderBy(orderQuery);
        }
          
    }
}
