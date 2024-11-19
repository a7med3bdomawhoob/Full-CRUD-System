using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Responsibilities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobResponsibilities_jobs_Job_Id1",
                table: "JobResponsibilities");

            migrationBuilder.DropIndex(
                name: "IX_JobResponsibilities_Job_Id1",
                table: "JobResponsibilities");

            migrationBuilder.DropColumn(
                name: "Job_Id1",
                table: "JobResponsibilities");

            migrationBuilder.CreateIndex(
                name: "IX_JobResponsibilities_Job_Id",
                table: "JobResponsibilities",
                column: "Job_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobResponsibilities_jobs_Job_Id",
                table: "JobResponsibilities",
                column: "Job_Id",
                principalTable: "jobs",
                principalColumn: "Job_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobResponsibilities_jobs_Job_Id",
                table: "JobResponsibilities");

            migrationBuilder.DropIndex(
                name: "IX_JobResponsibilities_Job_Id",
                table: "JobResponsibilities");

            migrationBuilder.AddColumn<int>(
                name: "Job_Id1",
                table: "JobResponsibilities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobResponsibilities_Job_Id1",
                table: "JobResponsibilities",
                column: "Job_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_JobResponsibilities_jobs_Job_Id1",
                table: "JobResponsibilities",
                column: "Job_Id1",
                principalTable: "jobs",
                principalColumn: "Job_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
