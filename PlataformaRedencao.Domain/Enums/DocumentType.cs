using System.ComponentModel;

namespace PlataformaRedencao.Domain.Enums
{
    /// <summary>
    /// Enumeração que representa os tipos de documentos de identificação
    /// aceitos pelo domínio.
    /// 
    /// Define um conjunto fechado e estável de valores, utilizado
    /// como classificador para identificar a natureza de um documento.
    /// </summary>
    public enum DocumentType
    {
        /// <summary>
        /// Cadastro de Pessoas Físicas.
        /// Documento oficial de identificação fiscal de pessoas físicas
        /// no Brasil.
        /// </summary>
        [Description("CPF")]
        IndividualTaxpayerRegistry = 100,

        /// <summary>
        /// Registro Geral.
        /// Documento civil de identificação emitido pelos órgãos estaduais.
        /// </summary>
        [Description("RG")]
        GeneralRegistration = 101,

        /// <summary>
        /// Carteira Nacional de Habilitação.
        /// Documento que comprova a habilitação para condução de veículos
        /// e que também pode ser utilizado como documento de identificação.
        /// </summary>
        [Description("CNH")]
        NationalDriverLicense = 102,

        /// <summary>
        /// Cadastro Nacional da Pessoa Jurídica.
        /// Documento de identificação fiscal de pessoas jurídicas
        /// no Brasil.
        /// </summary>
        [Description("CNPJ")]
        NationalRegistryOfLegalEntities = 103
    }
}
