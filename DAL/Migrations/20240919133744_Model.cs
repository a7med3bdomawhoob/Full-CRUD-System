using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_requirement_jobs_Job_Id",
                table: "job_requirement");

            migrationBuilder.DropColumn(
                name: "Req11",
                table: "job_requirement");

            migrationBuilder.RenameColumn(
                name: "Job_Id",
                table: "job_requirement",
                newName: "job_Id");

            migrationBuilder.RenameIndex(
                name: "IX_job_requirement_Job_Id",
                table: "job_requirement",
                newName: "IX_job_requirement_job_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_job_requirement_jobs_job_Id",
                table: "job_requirement",
                column: "job_Id",
                principalTable: "jobs",
                principalColumn: "Job_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_requirement_jobs_job_Id",
                table: "job_requirement");

            migrationBuilder.RenameColumn(
                name: "job_Id",
                table: "job_requirement",
                newName: "Job_Id");

            migrationBuilder.RenameIndex(
                name: "IX_job_requirement_job_Id",
                table: "job_requirement",
                newName: "IX_job_requirement_Job_Id");

            migrationBuilder.AddColumn<string>(
                name: "Req11",
                table: "job_requirement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_job_requirement_jobs_Job_Id",
                table: "job_requirement",
                column: "Job_Id",
                principalTable: "jobs",
                principalColumn: "Job_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
