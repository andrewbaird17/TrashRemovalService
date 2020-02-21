using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class RemovedPropertyOfSelectPickUpDayFromEmployeeAndRemovedPropertyOfLastPickUpFromCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "SelectDayToView",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastPickUp",
                table: "Accounts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4dc5249e-8af2-4e8d-9bc2-2f4ca1f04bf6", "95bfab5b-6f8c-4a26-a4b9-9330e8cc6ac8", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c9a298fe-a6a3-48e7-b31c-c478cbab60fa", "b34cc078-6fd5-4075-af0f-f11b2ba809e2", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4dc5249e-8af2-4e8d-9bc2-2f4ca1f04bf6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9a298fe-a6a3-48e7-b31c-c478cbab60fa");

            migrationBuilder.AddColumn<int>(
                name: "SelectDayToView",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPickUp",
                table: "Accounts",
                type: "datetime2",
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
    }
}
