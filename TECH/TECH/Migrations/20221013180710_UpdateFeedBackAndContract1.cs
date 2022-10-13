using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TECH.Migrations
{
    public partial class UpdateFeedBackAndContract1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "PoliciesonEmployees",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EMI",
                table: "PoliciesonEmployees",
                type: "decimal(10,0)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EMI",
                table: "PoliciesonEmployees");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "PoliciesonEmployees",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
