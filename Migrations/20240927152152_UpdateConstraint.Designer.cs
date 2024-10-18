﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240927152152_UpdateConstraint")]
    partial class UpdateConstraint
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Administrador", b =>
                {
                    b.Property<int>("ID_Administrador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Administrador"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre_Completo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Administrador");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("WebApplication1.Models.Contrato", b =>
                {
                    b.Property<int>("ID_Contrato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Contrato"));

                    b.Property<string>("Condiciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Deposito")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Estado_Contrato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Finalizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Inicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_Inquilino")
                        .HasColumnType("int");

                    b.Property<int>("ID_Propiedad")
                        .HasColumnType("int");

                    b.Property<decimal>("Monto_Alquiler")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID_Contrato");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("WebApplication1.Models.Inquilino", b =>
                {
                    b.Property<int>("ID_Inquilino")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Inquilino"));

                    b.Property<string>("Documentos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado_Inquilino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Registro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Informacion_Contacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre_Completo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Inquilino");

                    b.ToTable("Inquilinos");
                });

            modelBuilder.Entity("WebApplication1.Models.Notificacion", b =>
                {
                    b.Property<int>("ID_Notificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Notificacion"));

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado_Lectura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado_Notificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Envio")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_Destinatario_Admin")
                        .HasColumnType("int");

                    b.Property<int>("ID_Destinatario_Inquilino")
                        .HasColumnType("int");

                    b.Property<string>("Prioridad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo_Notificacion")
                        .HasColumnType("int");

                    b.HasKey("ID_Notificacion");

                    b.ToTable("Notificaciones");
                });

            modelBuilder.Entity("WebApplication1.Models.Pago", b =>
                {
                    b.Property<int>("ID_Pago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Pago"));

                    b.Property<string>("Estado_Pago")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Pago")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_Contrato")
                        .HasColumnType("int");

                    b.Property<int>("ID_Metodo")
                        .HasColumnType("int");

                    b.Property<decimal>("Intereses_Mora")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Monto_Pago")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Notas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Referencia_Transaccion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Pago");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("WebApplication1.Models.Propiedad", b =>
                {
                    b.Property<int>("ID_Propiedad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Propiedad"));

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Coordenadas_GPS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Deposito_Requerido")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado_Propiedad")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha_Registro")
                        .HasColumnType("datetime2");

                    b.Property<int>("Numero_Banos")
                        .HasColumnType("int");

                    b.Property<int>("Numero_Habitaciones")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio_Alquiler")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Tipo_Propiedad")
                        .HasColumnType("int");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Propiedad");

                    b.ToTable("Propiedades");
                });

            modelBuilder.Entity("WebApplication1.Models.Usuario", b =>
                {
                    b.Property<int>("ID_Usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Usuario"));

                    b.Property<string>("Codigo_Administracion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion_Propiedad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Registro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre_Completo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Usuario");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
