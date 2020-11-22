﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VLI.SIOP.Operacao.Dados;

namespace easyharbour.Dados.Migrations
{
    [DbContext(typeof(AplicacaoContexto))]
    [Migration("20201122014127_addViagem")]
    partial class addViagem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("easyharbour.Model.Atracacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AtracacaoEfetiva");

                    b.Property<DateTime?>("Autorizacao");

                    b.Property<DateTime>("AvisoChegada");

                    b.Property<DateTime?>("Desatracacao");

                    b.Property<bool>("EmOperacao");

                    b.Property<bool>("Fundiado");

                    b.Property<string>("Navio");

                    b.Property<string>("Operador");

                    b.Property<DateTime?>("PrevisaoAtracacao");

                    b.Property<int>("Viagem");

                    b.HasKey("Id");

                    b.ToTable("Atracacoes");
                });

            modelBuilder.Entity("easyharbour.Model.TabuaMare", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Altura");

                    b.Property<DateTime>("Data");

                    b.HasKey("Id");

                    b.ToTable("TabuaMares");
                });

            modelBuilder.Entity("easyharbour.Model.Viagem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BercoGraoId");

                    b.Property<string>("Codigo");

                    b.Property<string>("Destuno");

                    b.Property<Guid>("NavioId");

                    b.Property<string>("Origem");

                    b.Property<double>("Quantidade");

                    b.Property<int>("Status");

                    b.Property<int>("TipoProduto");

                    b.HasKey("Id");

                    b.HasIndex("BercoGraoId");

                    b.HasIndex("NavioId");

                    b.ToTable("Viagens");
                });

            modelBuilder.Entity("easyharbour.Models.BercoGrao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CaladoMaximoTrecho");

                    b.Property<double>("CalaodAlta");

                    b.Property<double>("CalaodBaixa");

                    b.Property<double>("Comprimento");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Nome");

                    b.Property<double>("Prancha");

                    b.HasKey("Id");

                    b.ToTable("BercosGraos");
                });

            modelBuilder.Entity("easyharbour.Models.Navio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Beam");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Descritivo");

                    b.Property<double>("Draft");

                    b.HasKey("Id");

                    b.ToTable("Navios");
                });

            modelBuilder.Entity("easyharbour.Model.Viagem", b =>
                {
                    b.HasOne("easyharbour.Models.BercoGrao", "BercoGrao")
                        .WithMany()
                        .HasForeignKey("BercoGraoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("easyharbour.Models.Navio", "Navio")
                        .WithMany()
                        .HasForeignKey("NavioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
