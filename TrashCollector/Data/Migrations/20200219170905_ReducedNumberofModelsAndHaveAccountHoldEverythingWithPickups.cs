using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class ReducedNumberofModelsAndHaveAccountHoldEverythingWithPickups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountServices_AccountServicesId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountServices");

            migrationBuilder.DropTable(
                name: "PickUps");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountServicesId",
                table: "Accounts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9005686b-e8fa-4a6b-9dda-081f720d7625");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bea9050-104d-4172-bff5-d223cde9ab53");

            migrationBuilder.DropColumn(
                name: "AccountServicesId",
                table: "Accounts");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateSuspend",
                table: "Accounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsPickedUp",
                table: "Accounts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuspended",
                table: "Accounts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "OneTimePickup",
                table: "Accounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDateSuspend",
                table: "Accounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "92abc3e5-7aa1-4459-828e-db2a3e4ae57b", "ee7ab9bc-1c5c-4641-8f65-d526ea24e520", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c9002a7e-996f-4e59-a839-b8827320c032", "d6f74ca8-e837-4361-b8ef-8ca38b290e5a", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92abc3e5-7aa1-4459-828e-db2a3e4ae57b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9002a7e-996f-4e59-a839-b8827320c032");

            migrationBuilder.DropColumn(
                name: "EndDateSuspend",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IsPickedUp",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IsSuspended",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "OneTimePickup",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "StartDateSuspend",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "AccountServicesId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AccountServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDateSuspend = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSuspended = table.Column<bool>(type: "bit", nullable: false),
                    OneTimePickup = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDateSuspend = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PickUps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    IsPickedUp = table.Column<bool>(type: "bit", nullable: false),
                    PickUpDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickUps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PickUps_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PickUps_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9005686b-e8fa-4a6b-9dda-081f720d7625", "4cdeda4b-9e7b-415d-86ae-acce346a10b7", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9bea9050-104d-4172-bff5-d223cde9ab53", "2552923d-cc24-4a3c-a0c5-ebeb496a56d5", "Customer", "CUSTOMER" });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountServicesId",
                table: "Accounts",
                column: "AccountServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_PickUps_AccountId",
                table: "PickUps",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PickUps_EmployeeId",
                table: "PickUps",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountServices_AccountServicesId",
                table: "Accounts",
                column: "AccountServicesId",
                principalTable: "AccountServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
