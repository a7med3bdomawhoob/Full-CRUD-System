using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class OldReq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_requirement_jobs_Job_Id",
                table: "job_requirement");

            migrationBuilder.DropIndex(
                name: "IX_job_requirement_Job_Id",
                table: "job_requirement");

            migrationBuilder.AddColumn<int>(
                name: "Job_Id1",
                table: "job_requirement",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_job_requirement_Job_Id1",
                table: "job_requirement",
                column: "Job_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_job_requirement_jobs_Job_Id1",
                table: "job_requirement",
                column: "Job_Id1",
                principalTable: "jobs",
                principalColumn: "Job_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_job_requirement_jobs_Job_Id1",
                table: "job_requirement");

            migrationBuilder.DropIndex(
                name: "IX_job_requirement_Job_Id1",
                table: "job_requirement");

            migrationBuilder.DropColumn(
                name: "Job_Id1",
                table: "job_requirement");

            migrationBuilder.CreateIndex(
                name: "IX_job_requirement_Job_Id",
                table: "job_requirement",
                column: "Job_Id");

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
