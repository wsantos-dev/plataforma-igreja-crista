using System.ComponentModel;

namespace PlataformaIgrejaCrista.Domain.Enums
{
    /// <summary>
    /// Enumeration of identification document types accepted by the domain.
    /// Closed, stable set of values used to classify the nature of a document.
    /// </summary>
    public enum DocumentType
    {
        /// <summary>
        /// Brazilian individual taxpayer registry (CPF). Official tax identification for individuals.
        /// </summary>
        [Description("CPF")]
        IndividualTaxpayerRegistry = 100,

        /// <summary>
        /// General registration (RG). Civil identification document issued by state authorities.
        /// </summary>
        [Description("RG")]
        GeneralRegistration = 101,

        /// <summary>
        /// National driver license (CNH). Proves driving eligibility and may also serve as identification.
        /// </summary>
        [Description("CNH")]
        NationalDriverLicense = 102,

        /// <summary>
        /// Brazilian national registry of legal entities (CNPJ). Tax identification for legal entities.
        /// </summary>
        [Description("CNPJ")]
        NationalRegistryOfLegalEntities = 103
    }
}
