using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class TestR2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_requirement_jobs_Job_Id1",
                table: "job_requirement");

            migrationBuilder.AlterColumn<int>(
                name: "Job_Id1",
                table: "job_requirement",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_job_requirement_jobs_Job_Id1",
                table: "job_requirement",
                column: "Job_Id1",
                principalTable: "jobs",
                principalColumn: "Job_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_requirement_jobs_Job_Id1",
                table: "job_requirement");

            migrationBuilder.AlterColumn<int>(
                name: "Job_Id1",
                table: "job_requirement",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_job_requirement_jobs_Job_Id1",
                table: "job_requirement",
                column: "Job_Id1",
                principalTable: "jobs",
                principalColumn: "Job_Id");
        }
    }
}
