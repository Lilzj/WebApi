using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.repository.Extensions.Utility
{
    public static class QueryBuilder
    {
        public static string CreateOrderQuery<T>(string QueryString)
        {

            var param = QueryString.Trim().Split(',');

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

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

            return orderQuery;
        }
    }
}
