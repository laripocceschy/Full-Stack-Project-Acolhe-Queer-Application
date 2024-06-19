﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using acolhequeer.Models;

#nullable disable

namespace acolhequeer_app.Migrations
{
    [DbContext(typeof(AppDbContextt))]
    partial class AppDbContexttModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Atendimento", b =>
                {
                    b.Property<int>("Atendimento_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Atendimento_id"));

                    b.Property<DateTime?>("Data_in")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Data_out")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Data_psi")
                        .HasColumnType("datetime2");

                    b.Property<int>("Instituicao_id")
                        .HasColumnType("int");

                    b.Property<bool>("IsPsicologico")
                        .HasColumnType("bit");

                    b.Property<bool>("IsQuarto")
                        .HasColumnType("bit");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Usuario_id")
                        .HasColumnType("int");

                    b.HasKey("Atendimento_id");

                    b.HasIndex("Instituicao_id");

                    b.HasIndex("Usuario_id");

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("acolhequeer.Models.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnoFabricacao")
                        .HasColumnType("int");

                    b.Property<int>("AnoModelo")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Placa")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("acolhequeer_app.Models.Instituicao", b =>
                {
                    b.Property<int>("instituicao_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("instituicao_id"));

                    b.Property<bool>("adm_validacao")
                        .HasColumnType("bit");

                    b.Property<bool>("bool_atd")
                        .HasColumnType("bit");

                    b.Property<string>("cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descricao_casa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("endereco_bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("endereco_cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("endereco_cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("endereco_estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("endereco_numero")
                        .HasColumnType("int");

                    b.Property<string>("endereco_rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("n_vagas")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pix_doacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("qtd_disponibilidade")
                        .HasColumnType("int");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("instituicao_id");

                    b.ToTable("Instituicao");
                });

            modelBuilder.Entity("acolhequeer_app.Models.Usuario", b =>
                {
                    b.Property<int>("Usuario_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Usuario_id"));

                    b.Property<bool>("Bool_admin")
                        .HasColumnType("bit");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco_bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco_cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco_cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco_estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco_logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Endereco_numero")
                        .HasColumnType("int");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome_social")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Usuario_id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Atendimento", b =>
                {
                    b.HasOne("acolhequeer_app.Models.Instituicao", "Instituicao")
                        .WithMany()
                        .HasForeignKey("Instituicao_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("acolhequeer_app.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("Usuario_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instituicao");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
