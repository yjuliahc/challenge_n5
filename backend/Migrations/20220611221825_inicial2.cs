using Microsoft.EntityFrameworkCore.Migrations;

namespace Challenge_n5.Migrations
{
    public partial class inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "tipoPermisos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "tipoPermisoId",
                table: "permisos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreEmpleado",
                table: "permisos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoEmpleado",
                table: "permisos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_permisos_tipoPermisos_tipoPermisoId",
                table: "permisos",
                column: "tipoPermisoId",
                principalTable: "tipoPermisos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "tipoPermisos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TipoPermisoId",
                table: "permisos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "NombreEmpleado",
                table: "permisos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoEmpleado",
                table: "permisos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_permisos_tipoPermisos_TipoPermisoId",
                table: "permisos",
                column: "TipoPermisoId",
                principalTable: "tipoPermisos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
