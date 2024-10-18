using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Inquilinos_InquilinoId",
                table: "Contratos");

            migrationBuilder.DropIndex(
                name: "IX_Contratos_InquilinoId",
                table: "Contratos");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Inquilinos",
                newName: "Nombre_Completo");

            migrationBuilder.RenameColumn(
                name: "NombreCompleto",
                table: "Inquilinos",
                newName: "Informacion_Contacto");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Inquilinos",
                newName: "Estado_Inquilino");

            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "Inquilinos",
                newName: "Documentos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Inquilinos",
                newName: "ID_Inquilino");

            migrationBuilder.RenameColumn(
                name: "PropiedadId",
                table: "Contratos",
                newName: "ID_Propiedad");

            migrationBuilder.RenameColumn(
                name: "InquilinoId",
                table: "Contratos",
                newName: "ID_Inquilino");

            migrationBuilder.RenameColumn(
                name: "FechaInicio",
                table: "Contratos",
                newName: "Fecha_Inicio");

            migrationBuilder.RenameColumn(
                name: "FechaFin",
                table: "Contratos",
                newName: "Fecha_Finalizacion");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Contratos",
                newName: "ID_Contrato");

            migrationBuilder.RenameColumn(
                name: "NombreCompleto",
                table: "Administradores",
                newName: "Nombre_Completo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Administradores",
                newName: "ID_Administrador");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_Registro",
                table: "Inquilinos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Condiciones",
                table: "Contratos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Deposito",
                table: "Contratos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Estado_Contrato",
                table: "Contratos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Monto_Alquiler",
                table: "Contratos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    ID_Notificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_Notificacion = table.Column<int>(type: "int", nullable: false),
                    Fecha_Envio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_Destinatario_Admin = table.Column<int>(type: "int", nullable: false),
                    ID_Destinatario_Inquilino = table.Column<int>(type: "int", nullable: false),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado_Notificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prioridad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado_Lectura = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.ID_Notificacion);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    ID_Pago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Contrato = table.Column<int>(type: "int", nullable: false),
                    Monto_Pago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha_Pago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_Metodo = table.Column<int>(type: "int", nullable: false),
                    Estado_Pago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Intereses_Mora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Referencia_Transaccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.ID_Pago);
                });

            migrationBuilder.CreateTable(
                name: "Propiedades",
                columns: table => new
                {
                    ID_Propiedad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_Propiedad = table.Column<int>(type: "int", nullable: false),
                    Numero_Habitaciones = table.Column<int>(type: "int", nullable: false),
                    Numero_Banos = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Precio_Alquiler = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deposito_Requerido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado_Propiedad = table.Column<int>(type: "int", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordenadas_GPS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha_Registro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propiedades", x => x.ID_Propiedad);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Completo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Codigo_Administracion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion_Propiedad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha_Registro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID_Usuario);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Propiedades");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Fecha_Registro",
                table: "Inquilinos");

            migrationBuilder.DropColumn(
                name: "Condiciones",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "Deposito",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "Estado_Contrato",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "Monto_Alquiler",
                table: "Contratos");

            migrationBuilder.RenameColumn(
                name: "Nombre_Completo",
                table: "Inquilinos",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "Informacion_Contacto",
                table: "Inquilinos",
                newName: "NombreCompleto");

            migrationBuilder.RenameColumn(
                name: "Estado_Inquilino",
                table: "Inquilinos",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Documentos",
                table: "Inquilinos",
                newName: "Direccion");

            migrationBuilder.RenameColumn(
                name: "ID_Inquilino",
                table: "Inquilinos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID_Propiedad",
                table: "Contratos",
                newName: "PropiedadId");

            migrationBuilder.RenameColumn(
                name: "ID_Inquilino",
                table: "Contratos",
                newName: "InquilinoId");

            migrationBuilder.RenameColumn(
                name: "Fecha_Inicio",
                table: "Contratos",
                newName: "FechaInicio");

            migrationBuilder.RenameColumn(
                name: "Fecha_Finalizacion",
                table: "Contratos",
                newName: "FechaFin");

            migrationBuilder.RenameColumn(
                name: "ID_Contrato",
                table: "Contratos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Nombre_Completo",
                table: "Administradores",
                newName: "NombreCompleto");

            migrationBuilder.RenameColumn(
                name: "ID_Administrador",
                table: "Administradores",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_InquilinoId",
                table: "Contratos",
                column: "InquilinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Inquilinos_InquilinoId",
                table: "Contratos",
                column: "InquilinoId",
                principalTable: "Inquilinos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
