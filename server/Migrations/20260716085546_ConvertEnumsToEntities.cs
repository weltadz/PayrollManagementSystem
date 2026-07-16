using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class ConvertEnumsToEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayrollStatus",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "EmploymentStatus",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PayFrequency",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SalaryType",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AttendanceStatus",
                table: "Attendances");

            migrationBuilder.AddColumn<Guid>(
                name: "PayrollStatusId",
                table: "Payrolls",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AttendanceStatusId",
                table: "Employees",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmploymentStatusId",
                table: "Employees",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PayFrequencyId",
                table: "Employees",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PayrollStatusId",
                table: "Employees",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SalaryTypeId",
                table: "Employees",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AttendanceStatusId",
                table: "Attendances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AttendanceStatuses",
                columns: table => new
                {
                    AttendanceStatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceStatuses", x => x.AttendanceStatusId);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentStatuses",
                columns: table => new
                {
                    EmploymentStatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentStatuses", x => x.EmploymentStatusId);
                });

            migrationBuilder.CreateTable(
                name: "PayFrequencies",
                columns: table => new
                {
                    PayFrequencyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayFrequencies", x => x.PayFrequencyId);
                });

            migrationBuilder.CreateTable(
                name: "PayrollStatuses",
                columns: table => new
                {
                    PayrollStatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollStatuses", x => x.PayrollStatusId);
                });

            migrationBuilder.CreateTable(
                name: "SalaryTypes",
                columns: table => new
                {
                    SalaryTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryTypes", x => x.SalaryTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_PayrollStatusId",
                table: "Payrolls",
                column: "PayrollStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AttendanceStatusId",
                table: "Employees",
                column: "AttendanceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmploymentStatusId",
                table: "Employees",
                column: "EmploymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PayFrequencyId",
                table: "Employees",
                column: "PayFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PayrollStatusId",
                table: "Employees",
                column: "PayrollStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SalaryTypeId",
                table: "Employees",
                column: "SalaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_AttendanceStatusId",
                table: "Attendances",
                column: "AttendanceStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_AttendanceStatuses_AttendanceStatusId",
                table: "Attendances",
                column: "AttendanceStatusId",
                principalTable: "AttendanceStatuses",
                principalColumn: "AttendanceStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AttendanceStatuses_AttendanceStatusId",
                table: "Employees",
                column: "AttendanceStatusId",
                principalTable: "AttendanceStatuses",
                principalColumn: "AttendanceStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmploymentStatuses_EmploymentStatusId",
                table: "Employees",
                column: "EmploymentStatusId",
                principalTable: "EmploymentStatuses",
                principalColumn: "EmploymentStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PayFrequencies_PayFrequencyId",
                table: "Employees",
                column: "PayFrequencyId",
                principalTable: "PayFrequencies",
                principalColumn: "PayFrequencyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PayrollStatuses_PayrollStatusId",
                table: "Employees",
                column: "PayrollStatusId",
                principalTable: "PayrollStatuses",
                principalColumn: "PayrollStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_SalaryTypes_SalaryTypeId",
                table: "Employees",
                column: "SalaryTypeId",
                principalTable: "SalaryTypes",
                principalColumn: "SalaryTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payrolls_PayrollStatuses_PayrollStatusId",
                table: "Payrolls",
                column: "PayrollStatusId",
                principalTable: "PayrollStatuses",
                principalColumn: "PayrollStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_AttendanceStatuses_AttendanceStatusId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AttendanceStatuses_AttendanceStatusId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmploymentStatuses_EmploymentStatusId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PayFrequencies_PayFrequencyId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PayrollStatuses_PayrollStatusId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_SalaryTypes_SalaryTypeId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_PayrollStatuses_PayrollStatusId",
                table: "Payrolls");

            migrationBuilder.DropTable(
                name: "AttendanceStatuses");

            migrationBuilder.DropTable(
                name: "EmploymentStatuses");

            migrationBuilder.DropTable(
                name: "PayFrequencies");

            migrationBuilder.DropTable(
                name: "PayrollStatuses");

            migrationBuilder.DropTable(
                name: "SalaryTypes");

            migrationBuilder.DropIndex(
                name: "IX_Payrolls_PayrollStatusId",
                table: "Payrolls");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AttendanceStatusId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmploymentStatusId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PayFrequencyId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PayrollStatusId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_SalaryTypeId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_AttendanceStatusId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "PayrollStatusId",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "AttendanceStatusId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmploymentStatusId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PayFrequencyId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PayrollStatusId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SalaryTypeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AttendanceStatusId",
                table: "Attendances");

            migrationBuilder.AddColumn<int>(
                name: "PayrollStatus",
                table: "Payrolls",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmploymentStatus",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PayFrequency",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SalaryType",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AttendanceStatus",
                table: "Attendances",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
