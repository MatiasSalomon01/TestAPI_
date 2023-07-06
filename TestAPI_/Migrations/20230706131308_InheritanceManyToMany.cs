using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TestAPI.Migrations
{
    /// <inheritdoc />
    public partial class InheritanceManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Student",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateTable(
                name: "TablaDos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaDos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TablaUno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaUno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TablaUnoDos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TablaUnoId = table.Column<int>(type: "integer", nullable: false),
                    TablaDosId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaUnoDos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TablaUnoDos_TablaDos_TablaDosId",
                        column: x => x.TablaDosId,
                        principalTable: "TablaDos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TablaUnoDos_TablaUno_TablaUnoId",
                        column: x => x.TablaUnoId,
                        principalTable: "TablaUno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TablaUnoDos_TablaDosId",
                table: "TablaUnoDos",
                column: "TablaDosId");

            migrationBuilder.CreateIndex(
                name: "IX_TablaUnoDos_TablaUnoId",
                table: "TablaUnoDos",
                column: "TablaUnoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TablaUnoDos");

            migrationBuilder.DropTable(
                name: "TablaDos");

            migrationBuilder.DropTable(
                name: "TablaUno");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Student",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
