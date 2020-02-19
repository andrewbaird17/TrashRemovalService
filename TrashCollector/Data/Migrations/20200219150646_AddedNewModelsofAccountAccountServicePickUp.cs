using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class AddedNewModelsofAccountAccountServicePickUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Adresses_AddressId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_PickUps_PickUpId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AddressId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PickUpId",
                table: "Customers");

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

            migrationBuilder.DropColumn(
                name: "EndDateSuspend",
                table: "PickUps");

            migrationBuilder.DropColumn(
                name: "IsPickedUp",
                table: "PickUps");

            migrationBuilder.DropColumn(
                name: "IsSuspended",
                table: "PickUps");

            migrationBuilder.DropColumn(
                name: "OneTimePickup",
                table: "PickUps");

            migrationBuilder.DropColumn(
                name: "PickUpDay",
                table: "PickUps");

            migrationBuilder.DropColumn(
                name: "StartDateSuspend",
                table: "PickUps");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PickUpId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "PickUps",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "PickUps",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "PickUps",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PickUpDate",
                table: "PickUps",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AccountServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPickedUp = table.Column<bool>(nullable: false),
                    OneTimePickup = table.Column<DateTime>(nullable: false),
                    AccountStartDate = table.Column<DateTime>(nullable: false),
                    AccountEndDate = table.Column<DateTime>(nullable: false),
                    IsSuspended = table.Column<bool>(nullable: false),
                    StartDateSuspend = table.Column<DateTime>(nullable: false),
                    EndDateSuspend = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<double>(nullable: false),
                    PickUpDay = table.Column<int>(nullable: false),
                    AccountServicesId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountServices_AccountServicesId",
                        column: x => x.AccountServicesId,
                        principalTable: "AccountServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Adresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Adresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "322169ab-c3ae-4b22-a51e-95b554ea6562", "30d8cc25-0392-4073-8236-e381656449cc", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "119a448b-4f5a-4fac-9478-38b2e0c6049e", "281f33ca-ecfa-4f7f-a456-647a5b48930f", "Customer", "CUSTOMER" });

            migrationBuilder.CreateIndex(
                name: "IX_PickUps_AccountId",
                table: "PickUps",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PickUps_AddressId",
                table: "PickUps",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PickUps_EmployeeId",
                table: "PickUps",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccountId",
                table: "Customers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountServicesId",
                table: "Accounts",
                column: "AccountServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AddressId",
                table: "Accounts",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Accounts_AccountId",
                table: "Customers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PickUps_Accounts_AccountId",
                table: "PickUps",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PickUps_Adresses_AddressId",
                table: "PickUps",
                column: "AddressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PickUps_Employees_EmployeeId",
                table: "PickUps",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Accounts_AccountId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_PickUps_Accounts_AccountId",
                table: "PickUps");

            migrationBuilder.DropForeignKey(
                name: "FK_PickUps_Adresses_AddressId",
                table: "PickUps");

            migrationBuilder.DropForeignKey(
                name: "FK_PickUps_Employees_EmployeeId",
                table: "PickUps");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountServices");

            migrationBuilder.DropIndex(
                name: "IX_PickUps_AccountId",
                table: "PickUps");

            migrationBuilder.DropIndex(
                name: "IX_PickUps_AddressId",
                table: "PickUps");

            migrationBuilder.DropIndex(
                name: "IX_PickUps_EmployeeId",
                table: "PickUps");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AccountId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "119a448b-4f5a-4fac-9478-38b2e0c6049e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "322169ab-c3ae-4b22-a51e-95b554ea6562");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "PickUps");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "PickUps");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "PickUps");

            migrationBuilder.DropColumn(
                name: "PickUpDate",
                table: "PickUps");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Customers");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateSuspend",
                table: "PickUps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsPickedUp",
                table: "PickUps",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuspended",
                table: "PickUps",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "OneTimePickup",
                table: "PickUps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PickUpDay",
                table: "PickUps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDateSuspend",
                table: "PickUps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "PickUpId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PickUpId",
                table: "Customers",
                column: "PickUpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Adresses_AddressId",
                table: "Customers",
                column: "AddressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_PickUps_PickUpId",
                table: "Customers",
                column: "PickUpId",
                principalTable: "PickUps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
