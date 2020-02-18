using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class UpdatingEmployeeandCustomerTableWithSpelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "201f98c3-5938-439c-8eea-076cc67d6f1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "235e0ac3-76e6-4a8f-a7ab-69d31c1de21e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62a045ab-9442-492b-a56c-909ff31d0a38");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "229784b3-96d0-4084-b4eb-d1dc9951c905", "db521b94-797c-499a-b019-8a96f4220e24", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "33a3442b-d817-4b22-8635-e9fd0fc9f8d7", "51305c0f-290a-4f6b-af4d-6da055626862", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3b8048a6-2863-40a4-993e-4c63f279c37c", "596b26b6-2571-4984-82e2-20a29b0111ee", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "229784b3-96d0-4084-b4eb-d1dc9951c905");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33a3442b-d817-4b22-8635-e9fd0fc9f8d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b8048a6-2863-40a4-993e-4c63f279c37c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "201f98c3-5938-439c-8eea-076cc67d6f1d", "686d94ad-033b-4777-b686-bc344aa4d438", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "235e0ac3-76e6-4a8f-a7ab-69d31c1de21e", "bee17dea-54c8-4c26-8d74-a4735380961d", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62a045ab-9442-492b-a56c-909ff31d0a38", "17f1ab24-d858-49f8-9f22-a9e8282b9403", "Customer", "CUSTOMER" });
        }
    }
}
