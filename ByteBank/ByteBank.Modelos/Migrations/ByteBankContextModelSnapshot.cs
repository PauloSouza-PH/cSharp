﻿// <auto-generated />
using System;
using ByteBank.Modelos.dbSys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ByteBank.Modelos.Migrations
{
    [DbContext(typeof(ByteBankContext))]
    partial class ByteBankContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ByteBank.Modelos.SistemaInterno.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cgc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ByteBank.Modelos.SistemaInterno.ContaCorrente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Agencia")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("ContadorSaquesNaoPermitidos")
                        .HasColumnType("int");

                    b.Property<int>("ContadorTransferenciasNaoPermitidas")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("ContaCorrente");
                });

            modelBuilder.Entity("ByteBank.Modelos.SistemaInterno.Movimentos", b =>
                {
                    b.Property<int>("MovimentosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContaCorrenteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("MovimentosId");

                    b.HasIndex("ContaCorrenteId");

                    b.ToTable("Movimentacoes");
                });

            modelBuilder.Entity("ByteBank.Modelos.SistemaInterno.ContaCorrente", b =>
                {
                    b.HasOne("ByteBank.Modelos.SistemaInterno.Cliente", null)
                        .WithMany("ContaCorrente")
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("ByteBank.Modelos.SistemaInterno.Movimentos", b =>
                {
                    b.HasOne("ByteBank.Modelos.SistemaInterno.ContaCorrente", null)
                        .WithMany("Movimentacoes")
                        .HasForeignKey("ContaCorrenteId");
                });
#pragma warning restore 612, 618
        }
    }
}
