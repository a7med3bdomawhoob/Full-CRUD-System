using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Arabic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name_ar",
                table: "services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Service_Description_ar",
                table: "services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Project_Description_ar",
                table: "projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Project_Name_ar",
                table: "projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "News_Description_ar",
                table: "news",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "News_Title_ar",
                table: "news",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Equipement_Description_ar",
                table: "equipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Equipement_Functions_ar",
                table: "equipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Equipement_Name_ar",
                table: "equipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Equipement_Parts_ar",
                table: "equipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Area_Description_ar",
                table: "areas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_ar",
                table: "areas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name_ar",
                table: "services");

            migrationBuilder.DropColumn(
                name: "Service_Description_ar",
                table: "services");

            migrationBuilder.DropColumn(
                name: "Project_Description_ar",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "Project_Name_ar",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "News_Description_ar",
                table: "news");

            migrationBuilder.DropColumn(
                name: "News_Title_ar",
                table: "news");

            migrationBuilder.DropColumn(
                name: "Equipement_Description_ar",
                table: "equipments");

            migrationBuilder.DropColumn(
                name: "Equipement_Functions_ar",
                table: "equipments");

            migrationBuilder.DropColumn(
                name: "Equipement_Name_ar",
                table: "equipments");

            migrationBuilder.DropColumn(
                name: "Equipement_Parts_ar",
                table: "equipments");

            migrationBuilder.DropColumn(
                name: "Area_Description_ar",
                table: "areas");

            migrationBuilder.DropColumn(
                name: "Name_ar",
                table: "areas");
        }
    }
}
