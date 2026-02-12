using System.ComponentModel;

namespace PlataformaRedencao.Domain.Enums
{
    /// <summary>
    /// Defines a person's marital status.
    /// </summary>
    public enum MaritalStatus
    {
        [Description("Single")]
        Single = 0,

        [Description("Married")]
        Married = 1,

        [Description("Widowed")]
        Widowed = 2,

        [Description("Divorced")]
        Divorced = 3
    }
}
