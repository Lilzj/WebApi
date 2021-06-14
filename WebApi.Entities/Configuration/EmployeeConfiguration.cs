using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities.Models;

namespace WebApi.Entities.Configuration
{
    class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData
                (
                    new Employee
                     {
                         name = "Clement",
                         Age = 36,
                         Position = "Software Engineer"
                     },
                    new Employee
                    {
                        name = "Clement",
                        Age = 36,
                        Position = "Software Engineer"
                    },
                    new Employee
                    {
                        name = "Clement",
                        Age = 36,
                        Position = "Software Engineer",
                    },
                    new Employee
                    {
                        name = "Clement",
                        Age = 36,
                        Position = "Software Engineer"
                    },
                    new Employee
                    {
                        name = "Clement",
                        Age = 36,
                        Position = "Software Engineer"
                    },
                    new Employee
                    {
                        name = "Clement",
                        Age = 36,
                        Position = "Software Engineer"
                    }
                );
        }
    }
}
