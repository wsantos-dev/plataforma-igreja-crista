using System.ComponentModel;

namespace PlataformaRedencao.Domain.Enums
{
    /// <summary>
    /// Define o estado civil da pessoa.
    /// </summary>
    public enum MaritalStatus
    {
        [Description("Solteiro(a)")]
        Single = 0,

        [Description("Casado(a)")]
        Married = 1,

        [Description("Viuvo(a)")]
        Widowed = 2,

        [Description("Divorciado(a)")]
        Divorced = 3
    }
}
