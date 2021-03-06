// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Entities;

namespace WebApi.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20210613172516_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApi.Entities.Models.Company", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("CompanyId");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = "de887ba4-9c6c-494a-8a11-6b3c68d91405",
                            Address = "7 Asanjo Way, Lekki",
                            Country = "Nigeria",
                            Name = "Decagon"
                        },
                        new
                        {
                            Id = "9c6f358f-7238-451e-b4de-006dcb8901b5",
                            Address = "7 Asanjo Way, Lekki",
                            Country = "Nigeria",
                            Name = "Aptech"
                        },
                        new
                        {
                            Id = "e1be87a5-667e-48bb-94fd-44e4bca7954b",
                            Address = "7 Asanjo Way, Lekki",
                            Country = "Nigeria",
                            Name = "Ideal Konsult"
                        },
                        new
                        {
                            Id = "5201a2f6-de8c-4a01-9c5d-2ead97449291",
                            Address = "7 Asanjo Way, Lekki",
                            Country = "Nigeria",
                            Name = "Bluepoint"
                        },
                        new
                        {
                            Id = "9e24c2bf-b284-4764-934f-cd5005171044",
                            Address = "7 Asanjo Way, Lekki",
                            Country = "Nigeria",
                            Name = "Vertex"
                        });
                });

            modelBuilder.Entity("WebApi.Entities.Models.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("EmployeeId");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CompanyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = "0506f978-3cac-4fde-b3ee-29d959c144c8",
                            Age = 36,
                            Position = "Software Engineer",
                            name = "Clement"
                        },
                        new
                        {
                            Id = "1ffc85b3-ba29-4a63-9b4b-b495835ec3f4",
                            Age = 36,
                            Position = "Software Engineer",
                            name = "Clement"
                        },
                        new
                        {
                            Id = "ff99470d-8a58-4f6e-aafc-c98bcfec31c8",
                            Age = 36,
                            Position = "Software Engineer",
                            name = "Clement"
                        },
                        new
                        {
                            Id = "5b37fbe5-ad96-4052-a68c-0ede184a864d",
                            Age = 36,
                            Position = "Software Engineer",
                            name = "Clement"
                        },
                        new
                        {
                            Id = "bb03ed10-f283-4a29-be20-277437fbff3a",
                            Age = 36,
                            Position = "Software Engineer",
                            name = "Clement"
                        },
                        new
                        {
                            Id = "736a6b20-5cc2-44ab-8f9e-cc704ac6f680",
                            Age = 36,
                            Position = "Software Engineer",
                            name = "Clement"
                        });
                });

            modelBuilder.Entity("WebApi.Entities.Models.Employee", b =>
                {
                    b.HasOne("WebApi.Entities.Models.Company", "Compnay")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId");

                    b.Navigation("Compnay");
                });

            modelBuilder.Entity("WebApi.Entities.Models.Company", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
