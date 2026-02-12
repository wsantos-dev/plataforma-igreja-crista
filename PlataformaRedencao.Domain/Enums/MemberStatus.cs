using System.ComponentModel;

namespace PlataformaRedencao.Domain.Enums
{
    /// <summary>
    /// Defines the current status of a member in the church.
    /// </summary>
    public enum MemberStatus
    {
        [Description("Active")]
        Active = 1,

        [Description("Suspended")]
        Suspended = 2,

        [Description("Removed")]
        Removed = 3,

        [Description("Deceased")]
        Deceased = 4
    }
}
