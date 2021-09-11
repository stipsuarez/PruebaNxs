using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaNxs.Webapi.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autors",
                columns: table => new
                {
                    Idautor = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(35)", maxLength: 35, nullable: false),
                    Fechanacimiento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Ciudad = table.Column<string>(type: "NVARCHAR2(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autors", x => x.Idautor);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    IdLibro = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false),
                    Nopaginas = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Ano = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Genero = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Idautor = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.IdLibro);
                    table.ForeignKey(
                        name: "FK_Libros_Autors_Idautor",
                        column: x => x.Idautor,
                        principalTable: "Autors",
                        principalColumn: "Idautor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_Idautor",
                table: "Libros",
                column: "Idautor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Autors");
        }
    }
}
