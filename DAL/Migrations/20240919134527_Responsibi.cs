using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Responsibi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobResponsibilities_jobs_Job_Id",
                table: "JobResponsibilities");

            migrationBuilder.RenameColumn(
                name: "Job_Id",
                table: "JobResponsibilities",
                newName: "job_Id");

            migrationBuilder.RenameIndex(
                name: "IX_JobResponsibilities_Job_Id",
                table: "JobResponsibilities",
                newName: "IX_JobResponsibilities_job_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobResponsibilities_jobs_job_Id",
                table: "JobResponsibilities",
                column: "job_Id",
                principalTable: "jobs",
                principalColumn: "Job_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobResponsibilities_jobs_job_Id",
                table: "JobResponsibilities");

            migrationBuilder.RenameColumn(
                name: "job_Id",
                table: "JobResponsibilities",
                newName: "Job_Id");

            migrationBuilder.RenameIndex(
                name: "IX_JobResponsibilities_job_Id",
                table: "JobResponsibilities",
                newName: "IX_JobResponsibilities_Job_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobResponsibilities_jobs_Job_Id",
                table: "JobResponsibilities",
                column: "Job_Id",
                principalTable: "jobs",
                principalColumn: "Job_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
