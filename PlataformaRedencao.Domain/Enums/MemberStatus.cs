using System.ComponentModel;

namespace PlataformaRedencao.Domain.Enums
{
    /// <summary>
    /// Define a situação atual do membro na igreja.
    /// </summary>
    public enum MemberStatus
    {
        [Description("Ativo")]
        Active = 1,

        [Description("Afastado")]
        Suspended = 2,

        [Description("Desligado")]
        Removed = 3,

        [Description("Falecido")]
        Deceased = 4
    }
}
