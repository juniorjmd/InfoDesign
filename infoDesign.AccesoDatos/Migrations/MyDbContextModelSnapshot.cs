﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using infoDesign.AccesoDatos.Data;

#nullable disable

namespace infoDesign.AccesoDatos.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("infoDesign.modelos.HistoricoConsumos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<decimal>("Consumo")
                        .HasColumnType("decimal(20,10)");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(20,10)");

                    b.Property<decimal>("Perdida")
                        .HasColumnType("decimal(20,10)");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("Date");

                    b.Property<int>("idLinea")
                        .HasColumnType("int");

                    b.Property<int>("idTipCliente")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idLinea");

                    b.HasIndex("idTipCliente");

                    b.ToTable("HistoricoConsumos");
                });

            modelBuilder.Entity("infoDesign.modelos.Lineas", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.HasKey("id");

                    b.ToTable("Lineas");
                });

            modelBuilder.Entity("infoDesign.modelos.Tipo_clientes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.HasKey("id");

                    b.ToTable("Tipo_clientes");
                });

            modelBuilder.Entity("infoDesign.modelos.HistoricoConsumos", b =>
                {
                    b.HasOne("infoDesign.modelos.Lineas", "Linea")
                        .WithMany()
                        .HasForeignKey("idLinea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("infoDesign.modelos.Tipo_clientes", "tipo_Cliente")
                        .WithMany()
                        .HasForeignKey("idTipCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Linea");

                    b.Navigation("tipo_Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
