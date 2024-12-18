﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Equipement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Equipement_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Equipement_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Equipement_Parts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Equipement_Functions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipments", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equipments");
        }
    }
}
