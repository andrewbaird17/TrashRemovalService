using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class AddedDateTimeLastPickUpToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "014b542e-f8cc-4eb3-8554-5427d0cbf1b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86875edb-6dd3-48fa-b85a-24b3093a9bb7");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPickUp",
                table: "Accounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c670bda-9e87-4fa7-99d4-8ab93827397e", "841d4101-fb57-4049-852f-7f06a587132a", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "431d13a3-d692-4a49-b700-09ab127356fd", "7fdb1bb8-f760-49c9-9a56-0532bbe329fd", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "431d13a3-d692-4a49-b700-09ab127356fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c670bda-9e87-4fa7-99d4-8ab93827397e");

            migrationBuilder.DropColumn(
                name: "LastPickUp",
                table: "Accounts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "014b542e-f8cc-4eb3-8554-5427d0cbf1b2", "a39be15f-17fe-482c-a101-08a92e5e05f1", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86875edb-6dd3-48fa-b85a-24b3093a9bb7", "1af62bee-26c8-49e8-aaea-a00fdef83d3e", "Customer", "CUSTOMER" });
        }
    }
}
