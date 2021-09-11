﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using PruebaNxs.DataAccess;

namespace PruebaNxs.Webapi.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApiLibros.Models.Autor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("Idautor")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("NVARCHAR2(25)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("NVARCHAR2(40)");

                    b.Property<DateTime>("Fechanacimiento")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("NVARCHAR2(35)");

                    b.HasKey("id");

                    b.ToTable("Autors");
                });

            modelBuilder.Entity("WebApiLibros.Models.Libro", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("IdLibro")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ano")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<int>("Idautor")
                        .IsRequired()
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Nopaginas")
                        .IsRequired()
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("NVARCHAR2(40)");

                    b.HasKey("id");

                    b.HasIndex("Idautor");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("WebApiLibros.Models.Libro", b =>
                {
                    b.HasOne("WebApiLibros.Models.Autor", "IdautorNavigation")
                        .WithMany("Libros")
                        .HasForeignKey("Idautor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdautorNavigation");
                });

            modelBuilder.Entity("WebApiLibros.Models.Autor", b =>
                {
                    b.Navigation("Libros");
                });
#pragma warning restore 612, 618
        }
    }
}