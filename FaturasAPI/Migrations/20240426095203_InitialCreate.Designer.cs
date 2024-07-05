﻿// <auto-generated />
using System;
using FaturasAPI.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace FaturasAPI.Migrations
{
    [DbContext(typeof(FaturaContext))]
    [Migration("20240426095203_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FaturasAPI.Models.FaturaItem", b =>
                {
                    b.Property<long>("B_NifAdquirente")
                        .HasPrecision(9)
                        .HasColumnType("NUMBER(9)")
                        .HasColumnName("B")
                        .HasComment("Nif do Adquirente")
                        .HasAnnotation("Relational:JsonPropertyName", "B");

                    b.Property<string>("G_IdentificacaoUnicaDocumento")
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR2(60)")
                        .HasColumnName("G")
                        .HasComment("Identificacao unica do documento")
                        .HasAnnotation("Relational:JsonPropertyName", "G");

                    b.Property<long>("A_NifEmitente")
                        .HasPrecision(9)
                        .HasColumnType("NUMBER(9)")
                        .HasColumnName("A")
                        .HasComment("Nif do Emitente")
                        .HasAnnotation("Relational:JsonPropertyName", "A");

                    b.Property<string>("C_PaisAdquirente")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("NVARCHAR2(12)")
                        .HasColumnName("C")
                        .HasComment("Pais do adquirente")
                        .HasAnnotation("Relational:JsonPropertyName", "C");

                    b.Property<string>("D_TipoDocumento")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("NVARCHAR2(2)")
                        .HasColumnName("D")
                        .HasComment("Tipo de Documento")
                        .HasAnnotation("Relational:JsonPropertyName", "D");

                    b.Property<string>("E_EstadoDocumento")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("NVARCHAR2(1)")
                        .HasColumnName("E")
                        .HasComment("Estado do documento")
                        .HasAnnotation("Relational:JsonPropertyName", "E");

                    b.Property<DateTime>("F_DataDocumento")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("F")
                        .HasComment("Data do documento")
                        .HasAnnotation("Relational:JsonPropertyName", "F");

                    b.Property<string>("H_AtCud")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("NVARCHAR2(70)")
                        .HasColumnName("H")
                        .HasComment("ATCUD")
                        .HasAnnotation("Relational:JsonPropertyName", "H");

                    b.Property<string>("I1_EspacoFiscal")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("NVARCHAR2(5)")
                        .HasColumnName("I1")
                        .HasComment("Espaco fiscal")
                        .HasAnnotation("Relational:JsonPropertyName", "I1");

                    b.Property<decimal?>("I2_BaseTributavelIva_Isento_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("I2")
                        .HasComment("Base tributavel isenta de IVA")
                        .HasAnnotation("Relational:JsonPropertyName", "I2");

                    b.Property<decimal?>("I3_BaseTributavelIva_TaxaReduzida_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("I3")
                        .HasComment("Base tributavel de IVA a taxa reduzida")
                        .HasAnnotation("Relational:JsonPropertyName", "I3");

                    b.Property<decimal?>("I4_TotalIva_TaxaReduzida_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("I4")
                        .HasComment("Total de IVA a taxa reduzida")
                        .HasAnnotation("Relational:JsonPropertyName", "I4");

                    b.Property<decimal?>("I5_BaseTributavelIva_TaxaIntermedia_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("I5")
                        .HasComment("Base tributavel de IVA a taxa intermedia")
                        .HasAnnotation("Relational:JsonPropertyName", "I5");

                    b.Property<decimal?>("I6_TotalIva_TaxaIntermedia_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("I6")
                        .HasComment("Total de IVA a taxa intermedia")
                        .HasAnnotation("Relational:JsonPropertyName", "I6");

                    b.Property<decimal?>("I7_BaseTributavelIva_TaxaNormal_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("I7")
                        .HasComment("Base tributavel de IVA a taxa normal")
                        .HasAnnotation("Relational:JsonPropertyName", "I7");

                    b.Property<decimal?>("I8_TotalIva_TaxaNormal_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("I8")
                        .HasComment("Total de IVA a taxa normal")
                        .HasAnnotation("Relational:JsonPropertyName", "I8");

                    b.Property<string>("J1_EspacoFiscal")
                        .HasMaxLength(5)
                        .HasColumnType("NVARCHAR2(5)")
                        .HasColumnName("J1")
                        .HasComment("Espaco fiscal")
                        .HasAnnotation("Relational:JsonPropertyName", "J1");

                    b.Property<decimal?>("J2_BaseTributavelIva_Isento_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("J2")
                        .HasComment("Base tributavel isenta")
                        .HasAnnotation("Relational:JsonPropertyName", "J2");

                    b.Property<decimal?>("J3_BaseTributavelIva_TaxaReduzida_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("J3")
                        .HasComment("Base tributavel de IVA a taxa reduzida")
                        .HasAnnotation("Relational:JsonPropertyName", "J3");

                    b.Property<decimal?>("J4_TotalIva_TaxaReduzida_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("J4")
                        .HasComment("Total de IVA a taxa reduzida")
                        .HasAnnotation("Relational:JsonPropertyName", "J4");

                    b.Property<decimal?>("J5_BaseTributavelIva_TaxaIntermedia_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("J5")
                        .HasComment("Base tributavel de IVA a taxa intermedia")
                        .HasAnnotation("Relational:JsonPropertyName", "J5");

                    b.Property<decimal?>("J6_TotalIva_TaxaIntermedia_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("J6")
                        .HasComment("Total de IVA a taxa intermedia")
                        .HasAnnotation("Relational:JsonPropertyName", "J6");

                    b.Property<decimal?>("J7_BaseTributavelIva_TaxaNormal_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("J7")
                        .HasComment("Base tributavel de IVA a taxa normal")
                        .HasAnnotation("Relational:JsonPropertyName", "J7");

                    b.Property<decimal?>("J8_TotalIva_TaxaNormal_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("J8")
                        .HasComment("Total de IVA a taxa normal")
                        .HasAnnotation("Relational:JsonPropertyName", "J8");

                    b.Property<string>("K1_EspacoFiscal")
                        .HasMaxLength(5)
                        .HasColumnType("NVARCHAR2(5)")
                        .HasColumnName("K1")
                        .HasComment("Espaco fiscal")
                        .HasAnnotation("Relational:JsonPropertyName", "K1");

                    b.Property<decimal?>("K2_BaseTributavelIva_Isento_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("K2")
                        .HasComment("Base tributavel isenta")
                        .HasAnnotation("Relational:JsonPropertyName", "K2");

                    b.Property<decimal?>("K3_BaseTributavelIva_TaxaReduzida_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("K3")
                        .HasComment("Base tributavel de IVA a taxa reduzida")
                        .HasAnnotation("Relational:JsonPropertyName", "K3");

                    b.Property<decimal?>("K4_TotalIva_TaxaReduzida_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("K4")
                        .HasComment("Total de IVA a taxa reduzida")
                        .HasAnnotation("Relational:JsonPropertyName", "K4");

                    b.Property<decimal?>("K5_BaseTributavelIva_TaxaIntermedia_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("K5")
                        .HasComment("Base tributavel de IVA a taxa intermedia")
                        .HasAnnotation("Relational:JsonPropertyName", "K5");

                    b.Property<decimal?>("K6_TotalIva_TaxaIntermedia_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("K6")
                        .HasComment("Total de IVA a taxa intermedia")
                        .HasAnnotation("Relational:JsonPropertyName", "K6");

                    b.Property<decimal?>("K7_BaseTributavelIva_TaxaNormal_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("K7")
                        .HasComment("Base tributavel de IVA a taxa normal")
                        .HasAnnotation("Relational:JsonPropertyName", "K7");

                    b.Property<decimal?>("K8_TotalIva_TaxaNormal_EspacoFiscal")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("K8")
                        .HasComment("Total de IVA a taxa normal")
                        .HasAnnotation("Relational:JsonPropertyName", "K8");

                    b.Property<decimal?>("L_ValorNaoSujeito_Tributavel_IVA")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("L")
                        .HasComment("Nao sujeito / nao tributavel em IVA")
                        .HasAnnotation("Relational:JsonPropertyName", "L");

                    b.Property<decimal?>("M_ImpostoSelo")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("M")
                        .HasComment("Imposto do Selo")
                        .HasAnnotation("Relational:JsonPropertyName", "M");

                    b.Property<decimal>("N_TotalImpostos")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("N")
                        .HasComment("Total de impostos")
                        .HasAnnotation("Relational:JsonPropertyName", "N");

                    b.Property<decimal>("O_TotalDocumentoComImpostos")
                        .HasPrecision(9, 2)
                        .HasColumnType("DECIMAL(9,2)")
                        .HasColumnName("O")
                        .HasComment("Total do documento com impostos")
                        .HasAnnotation("Relational:JsonPropertyName", "O");

                    b.Property<decimal?>("P_RetencaoFonte")
                        .HasPrecision(9, 2)
                        .HasColumnType("NUMBER")
                        .HasColumnName("P")
                        .HasComment("Retencoes na fonte")
                        .HasAnnotation("Relational:JsonPropertyName", "P");

                    b.Property<string>("Q_Hash")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("NVARCHAR2(4)")
                        .HasColumnName("Q")
                        .HasComment("4 carateres do Hash")
                        .HasAnnotation("Relational:JsonPropertyName", "Q");

                    b.Property<short>("R_NrCertificado")
                        .HasPrecision(4)
                        .HasColumnType("NUMBER(4)")
                        .HasColumnName("R")
                        .HasComment("Nr do certificado")
                        .HasAnnotation("Relational:JsonPropertyName", "R");

                    b.Property<string>("S_OutrasInformacoes")
                        .HasMaxLength(65)
                        .HasColumnType("NVARCHAR2(65)")
                        .HasColumnName("S")
                        .HasComment("Outras Informacoes")
                        .HasAnnotation("Relational:JsonPropertyName", "S");

                    b.HasKey("B_NifAdquirente", "G_IdentificacaoUnicaDocumento");

                    b.HasIndex("G_IdentificacaoUnicaDocumento")
                        .IsUnique();

                    b.HasIndex(new[] { "F_DataDocumento" }, "Data_Emissao_documento");

                    b.ToTable("Faturas");
                });
#pragma warning restore 612, 618
        }
    }
}
