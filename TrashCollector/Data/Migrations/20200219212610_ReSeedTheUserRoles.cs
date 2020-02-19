using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class ReSeedTheUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92abc3e5-7aa1-4459-828e-db2a3e4ae57b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9002a7e-996f-4e59-a839-b8827320c032");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da038c14-75a6-4efa-8df5-4e2e33e9ae3c", "30fb52fb-60b2-46e9-a9a8-e5dae6b861b5", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a677f8f8-9a3b-496d-add6-81a9c47ebdeb", "ea96ec8b-0cf1-48b3-8adf-a3d2c3e25dcd", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a677f8f8-9a3b-496d-add6-81a9c47ebdeb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da038c14-75a6-4efa-8df5-4e2e33e9ae3c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "92abc3e5-7aa1-4459-828e-db2a3e4ae57b", "ee7ab9bc-1c5c-4641-8f65-d526ea24e520", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c9002a7e-996f-4e59-a839-b8827320c032", "d6f74ca8-e837-4361-b8ef-8ca38b290e5a", "Customer", "CUSTOMER" });
        }
    }
}
