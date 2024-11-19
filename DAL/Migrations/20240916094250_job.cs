using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class job : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    Job_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Job_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time_Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobs", x => x.Job_Id);
                });

            migrationBuilder.CreateTable(
                name: "job_requirement",
                columns: table => new
                {
                    JobRequirements_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Job_Id = table.Column<int>(type: "int", nullable: false),
                    Job_Id1 = table.Column<int>(type: "int", nullable: false),
                    Req1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Req2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Req3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Req4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Req5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Req6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Req7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Req8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Req9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Req10 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_requirement", x => x.JobRequirements_Id);
                    table.ForeignKey(
                        name: "FK_job_requirement_jobs_Job_Id1",
                        column: x => x.Job_Id1,
                        principalTable: "jobs",
                        principalColumn: "Job_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobResponsibilities",
                columns: table => new
                {
                    JobResponsibilities_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Job_Id = table.Column<int>(type: "int", nullable: false),
                    Job_Id1 = table.Column<int>(type: "int", nullable: false),
                    Res1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Res2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Res3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Res4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Res5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Res6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Res7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Res8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Res9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Res10 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobResponsibilities", x => x.JobResponsibilities_Id);
                    table.ForeignKey(
                        name: "FK_JobResponsibilities_jobs_Job_Id1",
                        column: x => x.Job_Id1,
                        principalTable: "jobs",
                        principalColumn: "Job_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_job_requirement_Job_Id1",
                table: "job_requirement",
                column: "Job_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_JobResponsibilities_Job_Id1",
                table: "JobResponsibilities",
                column: "Job_Id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "job_requirement");

            migrationBuilder.DropTable(
                name: "JobResponsibilities");

            migrationBuilder.DropTable(
                name: "jobs");
        }
    }
}
