﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using factnet_back;

#nullable disable

namespace factnetback.Migrations
{
    [DbContext(typeof(FacturationContext))]
    [Migration("20221125002731_updateClient")]
    partial class updateClient
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.ToTable("cliente", (string)null);

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
#pragma warning restore 612, 618
        }
    }
}