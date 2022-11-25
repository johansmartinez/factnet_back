﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using factnet_back;

#nullable disable

namespace factnetback.Migrations
{
    [DbContext(typeof(FacturationContext))]
    partial class FacturationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("factnet_back.Models.Cliente", b =>
                {
                    b.Property<string>("dni")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("apellidos")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("fechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombres")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("dni");

                    b.ToTable("CLIENTES", (string)null);

                    b.HasData(
                        new
                        {
                            dni = "00000",
                            apellidos = "PRUEBA",
                            direccion = "DIRECCIÓN DE PRUEBA",
                            fechaNacimiento = new DateTime(2000, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            nombres = "USUARIO"
                        });
                });

            modelBuilder.Entity("factnet_back.Models.Proveedor", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("id");

                    b.ToTable("PROVEEDORES", (string)null);

                    b.HasData(
                        new
                        {
                            id = new Guid("40b4111a-defd-4539-942c-0adc8225e413"),
                            nombre = "PROVEEDOR DE PRUEBA"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}