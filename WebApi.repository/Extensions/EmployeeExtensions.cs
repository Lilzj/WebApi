using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities.Models;

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

            var param = QueryString.Trim().Split(',');

            var properties = typeof(Employee).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var queryBuilder = new StringBuilder();

            foreach (var item in param)
            {
                if (string.IsNullOrWhiteSpace(item))
                    continue;

                var query = item.Split(" ")[0];

                var objectProp = properties.FirstOrDefault(x => x.Name.Equals(query, StringComparison
                    .InvariantCultureIgnoreCase));

                if (objectProp == null)
                    continue;

                var direction = item.EndsWith(" desc") ? "descending" : "ascending";

                queryBuilder.Append($"{objectProp.Name.ToString()} {direction}, ");

            }

            var orderQuery = queryBuilder.ToString().TrimEnd(',', ' ');

            if (string.IsNullOrWhiteSpace(orderQuery))
                return employees.OrderBy(e => e.name);

            return employees.OrderBy(orderQuery);
        }
          
    }
}
