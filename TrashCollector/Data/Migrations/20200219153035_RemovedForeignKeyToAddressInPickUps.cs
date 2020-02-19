using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class RemovedForeignKeyToAddressInPickUps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4864d4cc-1dbf-41dc-b290-3773a8398891");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1267f88-9317-4258-8084-5e803af9fe3f");

            migrationBuilder.DropColumn(
                name: "IsPickedUp",
                table: "AccountServices");

            migrationBuilder.AddColumn<bool>(
                name: "IsPickedUp",
                table: "PickUps",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a541fe64-5790-4f39-bbbd-fcdb3f652f1e", "ffe68695-f982-4e81-bd01-0866a74144b8", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "90fdbf0a-5b11-43bb-8314-b419438195b3", "2bac404c-792c-47d2-b14d-f2c96be05d1a", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90fdbf0a-5b11-43bb-8314-b419438195b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a541fe64-5790-4f39-bbbd-fcdb3f652f1e");

            migrationBuilder.DropColumn(
                name: "IsPickedUp",
                table: "PickUps");

            migrationBuilder.AddColumn<bool>(
                name: "IsPickedUp",
                table: "AccountServices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4864d4cc-1dbf-41dc-b290-3773a8398891", "5828dbf7-6c57-48a1-a760-15fbd4590a45", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f1267f88-9317-4258-8084-5e803af9fe3f", "8957564e-4a89-469c-97a6-65a8a37f0944", "Customer", "CUSTOMER" });
        }
    }
}
