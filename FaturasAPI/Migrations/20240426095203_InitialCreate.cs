using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaturasAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faturas",
                columns: table => new
                {
                    B = table.Column<long>(type: "NUMBER(9)", precision: 9, nullable: false, comment: "Nif do Adquirente"),
                    G = table.Column<string>(type: "NVARCHAR2(60)", maxLength: 60, nullable: false, comment: "Identificacao unica do documento"),
                    A = table.Column<long>(type: "NUMBER(9)", precision: 9, nullable: false, comment: "Nif do Emitente"),
                    C = table.Column<string>(type: "NVARCHAR2(12)", maxLength: 12, nullable: false, comment: "Pais do adquirente"),
                    D = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: false, comment: "Tipo de Documento"),
                    E = table.Column<string>(type: "NVARCHAR2(1)", maxLength: 1, nullable: false, comment: "Estado do documento"),
                    F = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false, comment: "Data do documento"),
                    H = table.Column<string>(type: "NVARCHAR2(70)", maxLength: 70, nullable: false, comment: "ATCUD"),
                    I1 = table.Column<string>(type: "NVARCHAR2(5)", maxLength: 5, nullable: false, comment: "Espaco fiscal"),
                    I2 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Base tributavel isenta de IVA"),
                    I3 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Base tributavel de IVA a taxa reduzida"),
                    I4 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Total de IVA a taxa reduzida"),
                    I5 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Base tributavel de IVA a taxa intermedia"),
                    I6 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Total de IVA a taxa intermedia"),
                    I7 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Base tributavel de IVA a taxa normal"),
                    I8 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Total de IVA a taxa normal"),
                    J1 = table.Column<string>(type: "NVARCHAR2(5)", maxLength: 5, nullable: true, comment: "Espaco fiscal"),
                    J2 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Base tributavel isenta"),
                    J3 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Base tributavel de IVA a taxa reduzida"),
                    J4 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Total de IVA a taxa reduzida"),
                    J5 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Base tributavel de IVA a taxa intermedia"),
                    J6 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Total de IVA a taxa intermedia"),
                    J7 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Base tributavel de IVA a taxa normal"),
                    J8 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Total de IVA a taxa normal"),
                    K1 = table.Column<string>(type: "NVARCHAR2(5)", maxLength: 5, nullable: true, comment: "Espaco fiscal"),
                    K2 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Base tributavel isenta"),
                    K3 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Base tributavel de IVA a taxa reduzida"),
                    K4 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Total de IVA a taxa reduzida"),
                    K5 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Base tributavel de IVA a taxa intermedia"),
                    K6 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Total de IVA a taxa intermedia"),
                    K7 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Base tributavel de IVA a taxa normal"),
                    K8 = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Total de IVA a taxa normal"),
                    L = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Nao sujeito / nao tributavel em IVA"),
                    M = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: true, comment: "Imposto do Selo"),
                    N = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: false, comment: "Total de impostos"),
                    O = table.Column<decimal>(type: "DECIMAL(9,2)", precision: 9, scale: 2, nullable: false, comment: "Total do documento com impostos"),
                    P = table.Column<decimal>(type: "NUMBER(9,2)", precision: 9, scale: 2, nullable: true, comment: "Retencoes na fonte"),
                    Q = table.Column<string>(type: "NVARCHAR2(4)", maxLength: 4, nullable: false, comment: "4 carateres do Hash"),
                    R = table.Column<short>(type: "NUMBER(4)", precision: 4, nullable: false, comment: "Nr do certificado"),
                    S = table.Column<string>(type: "NVARCHAR2(65)", maxLength: 65, nullable: true, comment: "Outras Informacoes")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faturas", x => new { x.B, x.G });
                });

            migrationBuilder.CreateIndex(
                name: "Data_Emissao_documento",
                table: "Faturas",
                column: "F");

            migrationBuilder.CreateIndex(
                name: "IX_Faturas_G",
                table: "Faturas",
                column: "G",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faturas");
        }
    }
}
