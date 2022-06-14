using Microsoft.EntityFrameworkCore.Migrations;

namespace Challenge_n5.Migrations
{
    public partial class inicial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permisos_tipoPermisos_tipoPermisoId",
                table: "permisos");

            migrationBuilder.RenameColumn(
                name: "tipoPermisoId",
                table: "permisos",
                newName: "TipoPermisoId");

            migrationBuilder.RenameIndex(
                name: "IX_permisos_tipoPermisoId",
                table: "permisos",
                newName: "IX_permisos_TipoPermisoId");

            migrationBuilder.AddForeignKey(
                name: "FK_permisos_tipoPermisos_TipoPermisoId",
                table: "permisos",
                column: "TipoPermisoId",
                principalTable: "tipoPermisos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permisos_tipoPermisos_TipoPermisoId",
                table: "permisos");

            migrationBuilder.RenameColumn(
                name: "TipoPermisoId",
                table: "permisos",
                newName: "tipoPermisoId");

            migrationBuilder.RenameIndex(
                name: "IX_permisos_TipoPermisoId",
                table: "permisos",
                newName: "IX_permisos_tipoPermisoId");

            migrationBuilder.AddForeignKey(
                name: "FK_permisos_tipoPermisos_tipoPermisoId",
                table: "permisos",
                column: "tipoPermisoId",
                principalTable: "tipoPermisos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
