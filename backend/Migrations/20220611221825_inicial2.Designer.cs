﻿// <auto-generated />
using System;
using Challenge_n5.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Challenge_n5.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220611221825_inicial2")]
    partial class inicial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Challenge_n5.Models.Permiso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApellidoEmpleado")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("FechaPermiso")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreEmpleado")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("tipoPermisoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("tipoPermisoId");

                    b.ToTable("permisos");
                });

            modelBuilder.Entity("Challenge_n5.Models.TipoPermiso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("tipoPermisos");
                });

            modelBuilder.Entity("Challenge_n5.Models.Permiso", b =>
                {
                    b.HasOne("Challenge_n5.Models.TipoPermiso", "TipoPermiso")
                        .WithMany()
                        .HasForeignKey("tipoPermisoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoPermiso");
                });
#pragma warning restore 612, 618
        }
    }
}