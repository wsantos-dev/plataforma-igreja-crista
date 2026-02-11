using System.ComponentModel;

namespace PlataformaRedencao.Domain.Enums
{
    /// <summary>
    /// Define o tipo de admissão do membro na igreja.
    /// </summary>
    public enum MemberAdmissionType
    {
        [Description("Batismo")]
        Baptism = 1,

        [Description("Aclamação")]
        Acclamation = 2
    }
}
