using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TECH.Migrations
{
    public partial class Create1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminLogin",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "varchar(50)", nullable: false),
                    PassWord = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLogin", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDetails",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "varchar(50)", nullable: true),
                    Address = table.Column<string>(type: "varchar(150)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", nullable: true),
                    CompanyURL = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDetails", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "EmpRegister",
                columns: table => new
                {
                    Empno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(type: "varchar(250)", nullable: true),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(10,0)", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: true),
                    UserName = table.Column<string>(type: "varchar(50)", nullable: true),
                    PassWord = table.Column<string>(type: "varchar(50)", nullable: true),
                    Address = table.Column<string>(type: "varchar(150)", nullable: true),
                    ContactNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    State = table.Column<string>(type: "varchar(50)", nullable: true),
                    Country = table.Column<string>(type: "varchar(50)", nullable: true),
                    City = table.Column<string>(type: "varchar(50)", nullable: true),
                    PolicyStatus = table.Column<string>(type: "varchar(50)", nullable: true),
                    PolicyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpRegister", x => x.Empno);
                });

            migrationBuilder.CreateTable(
                name: "HospitalInfo",
                columns: table => new
                {
                    HospitalId = table.Column<string>(type: "varchar(50)", nullable: false),
                    HospitalName = table.Column<string>(type: "varchar(50)", nullable: true),
                    PhoneNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    Location = table.Column<string>(type: "varchar(50)", nullable: true),
                    Url = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalInfo", x => x.HospitalId);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyName = table.Column<string>(type: "varchar(50)", nullable: true),
                    PolicyDesc = table.Column<string>(type: "varchar(50)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(10,0)", nullable: true),
                    Emi = table.Column<decimal>(type: "decimal(10,0)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    HospitalId = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.PolicyId);
                });

            migrationBuilder.CreateTable(
                name: "PoliciesonEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empno = table.Column<string>(type: "varchar(10)", nullable: true),
                    PolcyId = table.Column<int>(type: "int", nullable: false),
                    PolcyName = table.Column<string>(type: "varchar(50)", nullable: true),
                    PolicyAmount = table.Column<decimal>(type: "decimal(10,0)", nullable: true),
                    PolicyDuration = table.Column<decimal>(type: "decimal(10,0)", nullable: true),
                    PstartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Penddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyId = table.Column<string>(type: "varchar(50)", nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(50)", nullable: true),
                    Medical = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliciesonEmployees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolicyApprovalDetails",
                columns: table => new
                {
                    PolcyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(10,0)", nullable: true),
                    Status = table.Column<string>(type: "char(3)", nullable: true),
                    Reason = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyApprovalDetails", x => x.PolcyId);
                });

            migrationBuilder.CreateTable(
                name: "PolicyRequestDetails",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Empno = table.Column<int>(type: "int", nullable: true),
                    PoicyId = table.Column<int>(type: "int", nullable: true),
                    PolicyName = table.Column<string>(type: "varchar(50)", nullable: true),
                    PolicyAmount = table.Column<decimal>(type: "decimal(10,0)", nullable: true),
                    Emi = table.Column<decimal>(type: "decimal(10,0)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(50)", nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyRequestDetails", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "PolicyTotalDescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: true),
                    PolicyName = table.Column<string>(type: "varchar(50)", nullable: true),
                    PolicyDes = table.Column<string>(type: "varchar(250)", nullable: true),
                    PolicyAmount = table.Column<decimal>(type: "decimal(10,0)", nullable: true),
                    EMI = table.Column<decimal>(type: "decimal(10,0)", nullable: true),
                    PolicyDurationinMonths = table.Column<int>(type: "int", nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(50)", nullable: true),
                    MedicalId = table.Column<string>(type: "varchar(50)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyTotalDescription", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminLogin");

            migrationBuilder.DropTable(
                name: "CompanyDetails");

            migrationBuilder.DropTable(
                name: "EmpRegister");

            migrationBuilder.DropTable(
                name: "HospitalInfo");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "PoliciesonEmployees");

            migrationBuilder.DropTable(
                name: "PolicyApprovalDetails");

            migrationBuilder.DropTable(
                name: "PolicyRequestDetails");

            migrationBuilder.DropTable(
                name: "PolicyTotalDescription");
        }
    }
}
