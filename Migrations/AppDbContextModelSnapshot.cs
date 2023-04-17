﻿// <auto-generated />
using System;
using ApiSoftFinance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiSoftFinance.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ApiSoftFinance.Domain.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ContaBancariaId")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ClienteId");

                    b.HasIndex("ContaBancariaId")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ApiSoftFinance.Domain.ContaBancaria", b =>
                {
                    b.Property<int>("ContaBancariaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Agencia")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Senha")
                        .HasColumnType("longtext");

                    b.HasKey("ContaBancariaId");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("ApiSoftFinance.Domain.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TipoTransacaoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Transacoes");
                });

            modelBuilder.Entity("ApiSoftFinance.Domain.Cliente", b =>
                {
                    b.HasOne("ApiSoftFinance.Domain.ContaBancaria", "ContaBancaria")
                        .WithOne("Cliente")
                        .HasForeignKey("ApiSoftFinance.Domain.Cliente", "ContaBancariaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContaBancaria");
                });

            modelBuilder.Entity("ApiSoftFinance.Domain.Transacao", b =>
                {
                    b.HasOne("ApiSoftFinance.Domain.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ApiSoftFinance.Domain.ContaBancaria", b =>
                {
                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}