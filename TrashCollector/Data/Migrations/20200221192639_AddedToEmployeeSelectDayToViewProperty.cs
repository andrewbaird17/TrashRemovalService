using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class AddedToEmployeeSelectDayToViewProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56e59d96-cd16-4673-9415-c84b28cb2e38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3c7254c-ebea-4aea-99c6-523ed1580b3b");

            migrationBuilder.AddColumn<int>(
                name: "SelectDayToView",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "014b542e-f8cc-4eb3-8554-5427d0cbf1b2", "a39be15f-17fe-482c-a101-08a92e5e05f1", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86875edb-6dd3-48fa-b85a-24b3093a9bb7", "1af62bee-26c8-49e8-aaea-a00fdef83d3e", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "014b542e-f8cc-4eb3-8554-5427d0cbf1b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86875edb-6dd3-48fa-b85a-24b3093a9bb7");

            migrationBuilder.DropColumn(
                name: "SelectDayToView",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e3c7254c-ebea-4aea-99c6-523ed1580b3b", "5469025b-73f2-4fd4-859e-f63270e374de", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "56e59d96-cd16-4673-9415-c84b28cb2e38", "f0073496-b502-4c04-83e3-e0fdef2bb60f", "Customer", "CUSTOMER" });
        }
    }
}
