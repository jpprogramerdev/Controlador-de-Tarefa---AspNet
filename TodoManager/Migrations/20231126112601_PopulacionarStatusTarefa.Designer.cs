﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoManager.Context;

#nullable disable

namespace TodoManager.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231126112601_PopulacionarStatusTarefa")]
    partial class PopulacionarStatusTarefa
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TodoManager.Models.PrioridadeTarefa", b =>
                {
                    b.Property<int>("PRD_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PRD_Id"));

                    b.Property<string>("PRD_Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PRD_Id");

                    b.ToTable("PrioridadesTarefas");
                });

            modelBuilder.Entity("TodoManager.Models.StatusTarefa", b =>
                {
                    b.Property<int>("STS_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("STS_Id"));

                    b.Property<string>("STS_Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("STS_Id");

                    b.ToTable("StatusTarefas");
                });

            modelBuilder.Entity("TodoManager.Models.Tarefa", b =>
                {
                    b.Property<int>("TRF_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TRF_Id"));

                    b.Property<int?>("PrioridadeTarefaPRD_Id")
                        .HasColumnType("int");

                    b.Property<int?>("StatusTarefaSTS_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("TRF_DataConclusao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TRF_DataCriada")
                        .HasColumnType("datetime2");

                    b.Property<string>("TRF_Descrição")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TRF_PRD_Id")
                        .HasColumnType("int");

                    b.Property<int>("TRF_STS_Id")
                        .HasColumnType("int");

                    b.Property<string>("TRF_Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TRF_USU_Id")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioUSU_Id")
                        .HasColumnType("int");

                    b.HasKey("TRF_Id");

                    b.HasIndex("PrioridadeTarefaPRD_Id");

                    b.HasIndex("StatusTarefaSTS_Id");

                    b.HasIndex("UsuarioUSU_Id");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("TodoManager.Models.Usuario", b =>
                {
                    b.Property<int>("USU_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("USU_Id"));

                    b.Property<string>("USU_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USU_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USU_Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("USU_Id");

                    b.ToTable("Usuarios'");
                });

            modelBuilder.Entity("TodoManager.Models.Tarefa", b =>
                {
                    b.HasOne("TodoManager.Models.PrioridadeTarefa", "PrioridadeTarefa")
                        .WithMany("Tarefas")
                        .HasForeignKey("PrioridadeTarefaPRD_Id");

                    b.HasOne("TodoManager.Models.StatusTarefa", "StatusTarefa")
                        .WithMany("Tarefas")
                        .HasForeignKey("StatusTarefaSTS_Id");

                    b.HasOne("TodoManager.Models.Usuario", "Usuario")
                        .WithMany("Tarefas")
                        .HasForeignKey("UsuarioUSU_Id");

                    b.Navigation("PrioridadeTarefa");

                    b.Navigation("StatusTarefa");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TodoManager.Models.PrioridadeTarefa", b =>
                {
                    b.Navigation("Tarefas");
                });

            modelBuilder.Entity("TodoManager.Models.StatusTarefa", b =>
                {
                    b.Navigation("Tarefas");
                });

            modelBuilder.Entity("TodoManager.Models.Usuario", b =>
                {
                    b.Navigation("Tarefas");
                });
#pragma warning restore 612, 618
        }
    }
}
