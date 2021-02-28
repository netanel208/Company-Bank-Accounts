using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyBankAccountsApp.Migrations
{
    public partial class AddCompaniesHoldings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompaniesHoldings",
                columns: table => new
                {
                    CompanyID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Holding = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniesHoldings", x => x.CompanyID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompaniesHoldings");
        }
    }
}
