using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class TookOutFKOfAddressInPickUpTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PickUps_Adresses_AddressId",
                table: "PickUps");

            migrationBuilder.DropIndex(
                name: "IX_PickUps_AddressId",
                table: "PickUps");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "119a448b-4f5a-4fac-9478-38b2e0c6049e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "322169ab-c3ae-4b22-a51e-95b554ea6562");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "PickUps");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4864d4cc-1dbf-41dc-b290-3773a8398891", "5828dbf7-6c57-48a1-a760-15fbd4590a45", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f1267f88-9317-4258-8084-5e803af9fe3f", "8957564e-4a89-469c-97a6-65a8a37f0944", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4864d4cc-1dbf-41dc-b290-3773a8398891");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1267f88-9317-4258-8084-5e803af9fe3f");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "PickUps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "322169ab-c3ae-4b22-a51e-95b554ea6562", "30d8cc25-0392-4073-8236-e381656449cc", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "119a448b-4f5a-4fac-9478-38b2e0c6049e", "281f33ca-ecfa-4f7f-a456-647a5b48930f", "Customer", "CUSTOMER" });

            migrationBuilder.CreateIndex(
                name: "IX_PickUps_AddressId",
                table: "PickUps",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_PickUps_Adresses_AddressId",
                table: "PickUps",
                column: "AddressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
