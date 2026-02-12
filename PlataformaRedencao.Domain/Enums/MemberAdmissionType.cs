using System.ComponentModel;

namespace PlataformaRedencao.Domain.Enums
{
    /// <summary>
    /// Defines the type of member admission to the church.
    /// </summary>
    public enum MemberAdmissionType
    {
        [Description("Baptism")]
        Baptism = 1,

        [Description("Acclamation")]
        Acclamation = 2
    }
}
