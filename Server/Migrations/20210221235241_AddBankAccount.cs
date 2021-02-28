using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyBankAccountsApp.Migrations
{
    public partial class AddBankAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CompaniesHoldings",
                table: "CompaniesHoldings");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyID",
                table: "CompaniesHoldings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "CompaniesHoldings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompaniesHoldings",
                table: "CompaniesHoldings",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CompaniesHoldings",
                table: "CompaniesHoldings");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "CompaniesHoldings");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyID",
                table: "CompaniesHoldings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompaniesHoldings",
                table: "CompaniesHoldings",
                column: "CompanyID");
        }
    }
}
