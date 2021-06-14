using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { "de887ba4-9c6c-494a-8a11-6b3c68d91405", "7 Asanjo Way, Lekki", "Nigeria", "Decagon" },
                    { "9c6f358f-7238-451e-b4de-006dcb8901b5", "7 Asanjo Way, Lekki", "Nigeria", "Aptech" },
                    { "e1be87a5-667e-48bb-94fd-44e4bca7954b", "7 Asanjo Way, Lekki", "Nigeria", "Ideal Konsult" },
                    { "5201a2f6-de8c-4a01-9c5d-2ead97449291", "7 Asanjo Way, Lekki", "Nigeria", "Bluepoint" },
                    { "9e24c2bf-b284-4764-934f-cd5005171044", "7 Asanjo Way, Lekki", "Nigeria", "Vertex" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Position", "name" },
                values: new object[,]
                {
                    { "0506f978-3cac-4fde-b3ee-29d959c144c8", 36, null, "Software Engineer", "Clement" },
                    { "1ffc85b3-ba29-4a63-9b4b-b495835ec3f4", 36, null, "Software Engineer", "Clement" },
                    { "ff99470d-8a58-4f6e-aafc-c98bcfec31c8", 36, null, "Software Engineer", "Clement" },
                    { "5b37fbe5-ad96-4052-a68c-0ede184a864d", 36, null, "Software Engineer", "Clement" },
                    { "bb03ed10-f283-4a29-be20-277437fbff3a", 36, null, "Software Engineer", "Clement" },
                    { "736a6b20-5cc2-44ab-8f9e-cc704ac6f680", 36, null, "Software Engineer", "Clement" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "5201a2f6-de8c-4a01-9c5d-2ead97449291");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "9c6f358f-7238-451e-b4de-006dcb8901b5");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "9e24c2bf-b284-4764-934f-cd5005171044");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "de887ba4-9c6c-494a-8a11-6b3c68d91405");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: "e1be87a5-667e-48bb-94fd-44e4bca7954b");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: "0506f978-3cac-4fde-b3ee-29d959c144c8");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: "1ffc85b3-ba29-4a63-9b4b-b495835ec3f4");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: "5b37fbe5-ad96-4052-a68c-0ede184a864d");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: "736a6b20-5cc2-44ab-8f9e-cc704ac6f680");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: "bb03ed10-f283-4a29-be20-277437fbff3a");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: "ff99470d-8a58-4f6e-aafc-c98bcfec31c8");
        }
    }
}
