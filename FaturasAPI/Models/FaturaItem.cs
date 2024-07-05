using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FaturasAPI.Models;


/// <summary>
/// Base model for An invoice
/// </summary>
[PrimaryKey(nameof(B_NifAdquirente), nameof(G_IdentificacaoUnicaDocumento))]
[Index(nameof(G_IdentificacaoUnicaDocumento), IsUnique =true)]
[Index(nameof(F_DataDocumento) , Name = "Data_Emissao_documento")] //for this, check https://www.learnentityframeworkcore.com/configuration/data-annotation-attributes/index-attribute
[Table("Faturas")]
public class FaturaItem
{

    /*
     * Especificações do QR Code obtido das finanças
     * https://info.portaldasfinancas.gov.pt/pt/apoio_contribuinte/Novas_regras_faturacao/Documents/Especificacoes_Tecnicas_Codigo_QR.pdf
     */

    

    /// <summary>
    /// Nif do Emitente
    /// </summary>
    [JsonProperty("A")]
    [JsonPropertyName("A")]
    [Required(ErrorMessage = "Necessário indicar o atributo 'A'")]
    [RegularExpression("^[0-9]{9}$", ErrorMessage = "O NIF Emitente indicado não é válido")]
    [Column("A")]
    [DisplayName("A")]
    [Comment("Nif do Emitente")]
    [Precision(9)]
    //[Key] não é valido o multiplo uso de KEY
    public UInt32 A_NifEmitente { get; set; }


    /// <summary>
    /// NIF do adquirente
    /// </summary>
    /*
     * https://learn.microsoft.com/en-us/answers/questions/357616/how-to-get-a-validating-attribute-name-from-a-prop.html
     */
    [Required(ErrorMessage = "Necessário indicar o atributo 'B'")]
    [RegularExpression("^[0-9]{9}$", ErrorMessage = "O NIF Adquirente indicado não é válido")]
    [JsonProperty("B")]
    [JsonPropertyName("B")]
    
    //[Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than 0")]
    [Column("B")]
    [Comment("Nif do Adquirente")]
    [Precision(9)]
    public UInt32 B_NifAdquirente { get; set; }

    /// <summary>
    /// País do adquirente
    /// </summary>
    [Required(ErrorMessage = "Necessário indicar o atributo 'C'")]
    [JsonProperty("C")]
    [JsonPropertyName("C")]
    [Column("C")]
    [Comment("Pais do adquirente")]
    [MaxLength(12)]
    public string C_PaisAdquirente { get; set; } = string.Empty;

    /// <summary>
    /// Tipo de Documento
    /// </summary>
    [Required(ErrorMessage = "Necessário indicar o atributo 'D'")]
    [JsonProperty("D")]
    [JsonPropertyName("D")]
    [Column("D")]
    [Comment("Tipo de Documento")]
    [MaxLength(2)]
    public string D_TipoDocumento { get; set; } = string.Empty;

    /// <summary>
    /// Estado do documento
    /// </summary>
    [Required(ErrorMessage = "Necessário indicar o atributo 'E'")]
    [JsonProperty("E")]
    [JsonPropertyName("E")]
    [Column("E")]
    [Comment("Estado do documento")]
    [MaxLength(1)]
    public string E_EstadoDocumento { get; set; } = string.Empty;

    /// <summary>
    /// Data do documento
    /// </summary>
    [Required(ErrorMessage = "Necessário indicar o atributo 'F'")]
    [JsonProperty("F")]
    [JsonPropertyName("F")]
    [Column("F")]
    [Comment("Data do documento")]
    [DataType(DataType.Date)]
    //[StringLength(8, ErrorMessage = "Tamanho da data do documento inválida.", MinimumLength = 8)]
    public DateTime F_DataDocumento { get; set; }

    /// <summary>
    /// Identificação única do documento
    /// </summary>
    [Required(ErrorMessage = "Necessário indicar o atributo 'G'")]
    [JsonProperty("G")]
    [JsonPropertyName("G")]
    [Column("G")]
    [Comment("Identificacao unica do documento")]
    [StringLength(60, ErrorMessage = "Tamanho da Identificacao unica do documento inválido.", MinimumLength = 1)]
    [MaxLength(60)]
    //[PrimaryKey] não é permitido aqui, ver https://learn.microsoft.com/pt-pt/ef/core/modeling/keys?tabs=data-annotations
    public string G_IdentificacaoUnicaDocumento { get; set; } = string.Empty;

    /// <summary>
    /// ATCUD
    /// </summary>
    [Required(ErrorMessage = "Necessário indicar o atributo 'H'")]
    [JsonProperty("H")]
    [JsonPropertyName("H")]
    [Column("H")]
    [Comment("ATCUD")]
    [StringLength(70, ErrorMessage = "Tamanho do ATCUD inválido.", MinimumLength = 1)]
    [MaxLength(70)]
    public string H_AtCud { get; set; } = string.Empty;

    /// <summary>
    /// Espaço fiscal 
    /// </summary>   
    [Required(ErrorMessage = "Necessário indicar o atributo 'I1'")]
    [JsonProperty("I1")]
    [JsonPropertyName("I1")]
    [Column("I1")]
    [Comment("Espaco fiscal")]
    [MaxLength(5)]
    public string I1_EspacoFiscal { get; set; } = string.Empty;

    /// <summary>
    /// Base tributável isenta de IVA
    /// </summary>
    [JsonProperty("I2")]
    [JsonPropertyName("I2")]
    [Column("I2")]
    [Comment("Base tributavel isenta de IVA")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9,2)]
    public decimal? I2_BaseTributavelIva_Isento_EspacoFiscal { get; set; }

    /// <summary>
    /// Base tributável de IVA à taxa reduzida
    /// </summary>
    [JsonProperty("I3")]
    [JsonPropertyName("I3")]
    [Column("I3")]
    [Comment("Base tributavel de IVA a taxa reduzida")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9,2)]
    public decimal? I3_BaseTributavelIva_TaxaReduzida_EspacoFiscal { get; set; }

    /// <summary>
    /// Total de IVA à taxa reduzida
    /// </summary>
    [JsonProperty("I4")]
    [JsonPropertyName("I4")]
    [Column("I4")]
    [Comment("Total de IVA a taxa reduzida")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? I4_TotalIva_TaxaReduzida_EspacoFiscal { get; set; }

    /// <summary>
    /// Base tributável de IVA à taxa intermédia
    /// </summary>
    [JsonProperty("I5")]
    [JsonPropertyName("I5")]
    [Column("I5")]
    [Comment("Base tributavel de IVA a taxa intermedia")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? I5_BaseTributavelIva_TaxaIntermedia_EspacoFiscal { get; set; }

    /// <summary>
    /// Total de IVA à taxa intermédia
    /// </summary>
    [JsonProperty("I6")]
    [JsonPropertyName("I6")]
    [Column("I6")]
    [Comment("Total de IVA a taxa intermedia")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? I6_TotalIva_TaxaIntermedia_EspacoFiscal { get; set; }

    /// <summary>
    /// Base tributável de IVA à taxa normal
    /// </summary>
    [JsonProperty("I7")]
    [JsonPropertyName("I7")]
    [Column("I7")]
    [Comment("Base tributavel de IVA a taxa normal")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? I7_BaseTributavelIva_TaxaNormal_EspacoFiscal { get; set; }

    /// <summary>
    /// Total de IVA à taxa normal
    /// </summary>
    [JsonProperty("I8")]
    [JsonPropertyName("I8")]
    [Column("I8")]
    [Comment("Total de IVA a taxa normal")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? I8_TotalIva_TaxaNormal_EspacoFiscal { get; set; }

    /// <summary>
    /// Espaço fiscal
    /// </summary>
    [JsonProperty("J1")]
    [JsonPropertyName("J1")]
    [Column("J1")]
    [Comment("Espaco fiscal")]
    [MaxLength(5)]
    public string? J1_EspacoFiscal { get; set; }

    /// <summary>
    /// Base tributável isenta
    /// </summary>
    [JsonProperty("J2")]
    [JsonPropertyName("J2")]
    [Column("J2")]
    [Comment("Base tributavel isenta")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? J2_BaseTributavelIva_Isento_EspacoFiscal { get; set; }

    /// <summary>
    /// Base tributável de IVA à taxa reduzida
    /// </summary>
    [JsonProperty("J3")]
    [JsonPropertyName("J3")]
    [Column("J3")]
    [Comment("Base tributavel de IVA a taxa reduzida")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? J3_BaseTributavelIva_TaxaReduzida_EspacoFiscal { get; set; }

    /// <summary>
    /// Total de IVA à taxa reduzida
    /// </summary>
    [JsonProperty("J4")]
    [JsonPropertyName("J4")]
    [Column("J4")]
    [Comment("Total de IVA a taxa reduzida")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? J4_TotalIva_TaxaReduzida_EspacoFiscal { get; set; }

    /// <summary>
    /// Base tributável de IVA à taxa intermédia
    /// </summary>
    [JsonProperty("J5")]
    [JsonPropertyName("J5")]
    [Column("J5")]
    [Comment("Base tributavel de IVA a taxa intermedia")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? J5_BaseTributavelIva_TaxaIntermedia_EspacoFiscal { get; set; }

    /// <summary>
    /// Total de IVA à taxa intermédia
    /// </summary>
    [JsonProperty("J6")]
    [JsonPropertyName("J6")]
    [Column("J6")]
    [Comment("Total de IVA a taxa intermedia")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? J6_TotalIva_TaxaIntermedia_EspacoFiscal { get; set; }

    /// <summary>
    /// Base tributável de IVA à taxa normal
    /// </summary>
    [JsonProperty("J7")]
    [JsonPropertyName("J7")]
    [Column("J7")]
    [Comment("Base tributavel de IVA a taxa normal")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? J7_BaseTributavelIva_TaxaNormal_EspacoFiscal { get; set; }

    /// <summary>
    /// Total de IVA à taxa normal
    /// </summary>
    [JsonProperty("J8")]
    [JsonPropertyName("J8")]
    [Column("J8")]
    [Comment("Total de IVA a taxa normal")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? J8_TotalIva_TaxaNormal_EspacoFiscal { get; set; }

    /// <summary>
    /// Espaço fiscal
    /// </summary>
    [JsonProperty("K1")]
    [JsonPropertyName("K1")]
    [Column("K1")]
    [Comment("Espaco fiscal")]
    [MaxLength(5)]
    public string? K1_EspacoFiscal { get; set; }

    /// <summary>
    /// Base tributável isenta
    /// </summary>
    [JsonProperty("K2")]
    [JsonPropertyName("K2")]
    [Column("K2")]
    [Comment("Base tributavel isenta")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? K2_BaseTributavelIva_Isento_EspacoFiscal { get; set; }

    /// <summary>
    /// Base tributável de IVA à taxa reduzida
    /// </summary>
    [JsonProperty("K3")]
    [JsonPropertyName("K3")]
    [Column("K3")]
    [Comment("Base tributavel de IVA a taxa reduzida")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? K3_BaseTributavelIva_TaxaReduzida_EspacoFiscal { get; set; }

    /// <summary>
    /// Total de IVA à taxa reduzida
    /// </summary>
    [JsonProperty("K4")]
    [JsonPropertyName("K4")]
    [Column("K4")]
    [Comment("Total de IVA a taxa reduzida")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? K4_TotalIva_TaxaReduzida_EspacoFiscal { get; set; }

    /// <summary>
    /// Base tributável de IVA à taxa intermédia
    /// </summary>
    [JsonProperty("K5")]
    [JsonPropertyName("K5")]
    [Column("K5")]
    [Comment("Base tributavel de IVA a taxa intermedia")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? K5_BaseTributavelIva_TaxaIntermedia_EspacoFiscal { get; set; }

    /// <summary>
    /// Total de IVA à taxa intermédia
    /// </summary>
    [JsonProperty("K6")]
    [JsonPropertyName("K6")]
    [Column("K6")]
    [Comment("Total de IVA a taxa intermedia")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? K6_TotalIva_TaxaIntermedia_EspacoFiscal { get; set; }

    /// <summary>
    /// Base tributável de IVA à taxa normal
    /// </summary>
    [JsonProperty("K7")]
    [JsonPropertyName("K7")]
    [Column("K7")]
    [Comment("Base tributavel de IVA a taxa normal")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? K7_BaseTributavelIva_TaxaNormal_EspacoFiscal { get; set; }

    /// <summary>
    /// Total de IVA à taxa normal
    /// </summary>
    [JsonProperty("K8")]
    [JsonPropertyName("K8")]
    [Column("K8")]
    [Comment("Total de IVA a taxa normal")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? K8_TotalIva_TaxaNormal_EspacoFiscal { get; set; }

    /// <summary>
    /// Não sujeito / não tributável em IVA
    /// </summary>
    [JsonProperty("L")]
    [JsonPropertyName("L")]
    [Column("L")]
    [Comment("Nao sujeito / nao tributavel em IVA")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? L_ValorNaoSujeito_Tributavel_IVA { get; set; }

    /// <summary>
    /// Imposto do Selo
    /// </summary>
    [JsonProperty("M")]
    [JsonPropertyName("M")]
    [Column("M")]
    [Comment("Imposto do Selo")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? M_ImpostoSelo { get; set; }

    /// <summary>
    /// Total de impostos
    /// </summary>
    [Required(ErrorMessage = "Necessário indicar o atributo 'N'")]
    [JsonProperty("N")]
    [JsonPropertyName("N")]
    [Column("N")]
    [Comment("Total de impostos")]
    [DisplayFormat(DataFormatString = "{0:C}")]
    [Precision(9, 2)]
    public decimal N_TotalImpostos { get; set; }

    /// <summary>
    /// Total do documento com impostos
    /// </summary>
    [Required(ErrorMessage = "Necessário indicar o atributo 'O'")]
    [JsonProperty("O")]
    [JsonPropertyName("O")]
    [Column("O")]
    [Comment("Total do documento com impostos")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal O_TotalDocumentoComImpostos { get; set; }

    /// <summary>
    /// Retenções na fonte
    /// </summary>
    [JsonProperty("P")]
    [JsonPropertyName("P")]
    [Column("P", TypeName = "NUMBER")]
    [Comment("Retencoes na fonte")]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Precision(9, 2)]
    public decimal? P_RetencaoFonte { get; set; }

    /// <summary>
    /// 4 carateres do Hash
    /// </summary>
    [Required(ErrorMessage = "Necessário indicar o atributo 'Q'")]
    [JsonProperty("Q")]
    [JsonPropertyName("Q")]
    [Column("Q")]
    [StringLength(maximumLength: 4, ErrorMessage = "O campo HASH é incorrecto.", MinimumLength = 4)]
    [Comment("4 carateres do Hash")]
    [RegularExpression("^\\S{4}$", ErrorMessage = "O campo HASH é incorrecto.")]
    [MaxLength(4)]    
    public string Q_Hash { get; set; } = string.Empty;

    /// <summary>
    /// Nº do certificado
    /// </summary>
    [Required(ErrorMessage = "Necessário indicar o atributo 'R'")]
    [JsonProperty("R")]
    [JsonPropertyName("R")]
    [Column("R")]
    [Comment("Nr do certificado")]
    [Precision(4)]
    [Range(0, 9999, ErrorMessage = "Nr do certificado fora os limites definidos")]
    //[StringLength(4, ErrorMessage = "O tamanho do campo HASH é incorrecto.", MinimumLength = 1)]
    public short R_NrCertificado { get; set; }

    /// <summary>
    /// Outras Informações
    /// </summary>
    [JsonProperty("S")]
    [JsonPropertyName("S")]
    [Column("S")]
    [Comment("Outras Informacoes")]
    [StringLength(65, ErrorMessage = "O tamanho do campo 'Outras Informações' excede o tamanho máximo", MinimumLength = 0)]
    [MaxLength(65)]
    public string? S_OutrasInformacoes { get; set; }
 }