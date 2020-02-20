using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class AddedDisplayNamesForMultipleItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "e3c7254c-ebea-4aea-99c6-523ed1580b3b", "5469025b-73f2-4fd4-859e-f63270e374de", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "56e59d96-cd16-4673-9415-c84b28cb2e38", "f0073496-b502-4c04-83e3-e0fdef2bb60f", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56e59d96-cd16-4673-9415-c84b28cb2e38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3c7254c-ebea-4aea-99c6-523ed1580b3b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da038c14-75a6-4efa-8df5-4e2e33e9ae3c", "30fb52fb-60b2-46e9-a9a8-e5dae6b861b5", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a677f8f8-9a3b-496d-add6-81a9c47ebdeb", "ea96ec8b-0cf1-48b3-8adf-a3d2c3e25dcd", "Customer", "CUSTOMER" });
        }
    }
}
