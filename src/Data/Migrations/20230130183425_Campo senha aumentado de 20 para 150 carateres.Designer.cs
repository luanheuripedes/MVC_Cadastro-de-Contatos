﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20230130183425_Campo senha aumentado de 20 para 150 carateres")]
    partial class Camposenhaaumentadode20para150carateres
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Data.Entities.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("celular");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("nome");

                    b.HasKey("Id")
                        .HasName("id");

                    b.ToTable("contato", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("DATETIME")
                        .HasColumnName("data_atualizacao");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("DATETIME")
                        .HasColumnName("data_cadastro");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("email");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("login");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("nome");

                    b.Property<string>("Perfil")
                        .IsRequired()
                        .HasColumnType("CHAR(2)")
                        .HasColumnName("perfil");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("senha");

                    b.HasKey("Id")
                        .HasName("id");

                    b.ToTable("usuario", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
