using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Challenge_n5.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tipoPermisos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoPermisos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "permisos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPermisoId = table.Column<int>(type: "int", nullable: true),
                    FechaPermiso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permisos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permisos_tipoPermisos_TipoPermisoId",
                        column: x => x.TipoPermisoId,
                        principalTable: "tipoPermisos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_permisos_TipoPermisoId",
                table: "permisos",
                column: "TipoPermisoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "permisos");

            migrationBuilder.DropTable(
                name: "tipoPermisos");
        }
    }
}
