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
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData
                (
                    new Company
                    {
                        Name = "Decagon",
                        Address = "7 Asanjo Way, Lekki",
                        Country = "Nigeria"
                    },
                    new Company
                    {
                        Name = "Aptech",
                        Address = "7 Asanjo Way, Lekki",
                        Country = "Nigeria"
                    },
                    new Company
                    {
                        Name = "Ideal Konsult",
                        Address = "7 Asanjo Way, Lekki",
                        Country = "Nigeria"
                    },
                    new Company
                    {
                        Name = "Bluepoint",
                        Address = "7 Asanjo Way, Lekki",
                        Country = "Nigeria"
                    },
                    new Company
                    {
                        Name = "Vertex",
                        Address = "7 Asanjo Way, Lekki",
                        Country = "Nigeria"
                    }
                );
        }
    }
}
